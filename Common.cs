using FayElf.Plugins.WeChat.Applets;
using FayElf.Plugins.WeChat.Applets.Model;
using FayElf.Plugins.WeChat.OfficialAccount;
using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng;
using XiaoFeng.Http;

/****************************************************************
*  Copyright © (2021) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2021-12-22 14:24:58                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 通用类
    /// </summary>
    public static class Common
    {
        #region 获取全局唯一后台接口调用凭据
        /// <summary>
        /// 获取全局唯一后台接口调用凭据
        /// </summary>
        /// <param name="appID">App ID</param>
        /// <param name="appSecret">密钥</param>
        /// <returns></returns>
        public static AccessTokenData GetAccessToken(string appID, string appSecret)
        {
            var AccessToken = XiaoFeng.Cache.CacheHelper.Get<AccessTokenData>("AccessToken" + appID);
            if (AccessToken.IsNotNullOrEmpty()) return AccessToken;
            var data = new AccessTokenData();
            var result = HttpHelper.GetHtml(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{HttpApi.HOST}/cgi-bin/token?grant_type=client_credential&appid={appID}&secret={appSecret}"
            });
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = result.Html.JsonToObject<AccessTokenData>();
                var dic = new Dictionary<int, string>
                {
                    {-1,"系统繁忙，此时请开发者稍候再试" },
                    {0,"请求成功" },
                    {40001,"AppSecret 错误或者 AppSecret 不属于这个小程序，请开发者确认 AppSecret 的正确性" },
                    {40002,"请确保 grant_type 字段值为 client_credential" },
                    {40013,"不合法的 AppID，请开发者检查 AppID 的正确性，避免异常字符，注意大小写" }
                };
                if (data.ErrCode != 0)
                {
                    data.ErrMsg += dic[data.ErrCode];
                }
                else
                    XiaoFeng.Cache.CacheHelper.Set("AccessToken" + appID, data, (data.ExpiresIn - 60) * 1000);
            }
            else
            {
                data.ErrMsg = "请求出错.";
                data.ErrCode = 500;
            }
            return data;
        }
        /// <summary>
        /// 获取全局唯一后台接口调用凭据
        /// </summary>
        /// <param name="config">配置</param>
        /// <returns></returns>
        public static AccessTokenData GetAccessToken(WeChatConfig config) => GetAccessToken(config.AppID, config.AppSecret);
        /// <summary>
        /// 获取全局唯一后台接口调用凭据
        /// </summary>
        /// <param name="weChatType">微信类型</param>
        /// <returns></returns>
        public static AccessTokenData GetAccessToken(WeChatType weChatType = WeChatType.OfficeAccount) => GetAccessToken(new Config().GetConfig(weChatType));
        #endregion

        #region 运行
        /// <summary>
        /// 运行
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="appID">appid</param>
        /// <param name="appSecret">密钥</param>
        /// <param name="fun">委托</param>
        /// <returns></returns>
        public static T Execute<T>(string appID, string appSecret, Func<AccessTokenData, T> fun) where T : BaseResult, new()
        {
            var aToken = GetAccessToken(appID, appSecret);
            if (aToken.ErrCode != 0)
            {
                return new T
                {
                    ErrCode = 500,
                    ErrMsg = aToken.ErrMsg
                };
            }
            return fun.Invoke(aToken);
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="path">请求路径</param>
        /// <param name="data">请求数据</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        public static T Execute<T>(string path, string data, Func<int, string>? errorMessage = null) where T : BaseResult, new()
        {
            var result = new HttpRequest()
            {
                Address = HttpApi.HOST + path,
                Method = HttpMethod.Post,
                BodyData = data
            }.GetResponse();
            var error = result.Html;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var val = result.Html.JsonToObject<T>();
                if (val.ErrCode == 0) return val;
                if (errorMessage != null)
                {
                    error = errorMessage.Invoke(val.ErrCode);
                }
            }
            return new T
            {
                ErrCode = 500,
                ErrMsg = error
            };
        }
        #endregion
    }
}