using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng;
using XiaoFeng.Http;
using FayElf.Plugins.WeChat.OfficialAccount.Model;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-16 14:32:27                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount
{
    /// <summary>
    /// 对应微信API的  "用户管理"=> "网页授权获取用户基本信息”
    /// http://mp.weixin.qq.com/wiki/17/c0f37d5704f0b64713d5d2c37b468d75.html
    /// </summary>
    public class OAuthAPI
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public OAuthAPI()
        {
            this.Config = Config.Current;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 配置
        /// </summary>
        public Config Config { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public AccessTokenModel AccessToken { get; set; }
        #endregion

        #region 方法

        #region 通过code换取网页授权access_token

        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="code">填写第一步获取的code参数</param>
        /// <returns></returns>
        public AccessTokenModel GetAccessToken(string code)
        {
            var config = this.Config.GetConfig(WeChatType.OfficeAccount);
            var AccessToken = XiaoFeng.Cache.CacheHelper.Get<AccessTokenModel>("AccessTokenModel" + config.AppID);
            if (AccessToken.IsNotNullOrEmpty())
            {
                if (AccessToken.ExpiresIn <= 60)
                {
                    return RefreshAccessToken();
                }
                return this.AccessToken = AccessToken;
            }
            var result = new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={config.AppID}&secret={config.AppSecret}&code={code}&grant_type=authorization_code"
            }.GetResponse();
            Config.WriteLog(result.Html);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return this.AccessToken = result.Html.JsonToObject<AccessTokenModel>();
            }
            else
            {
                return new AccessTokenModel
                {
                    ErrMsg = "请求出错.",
                    ErrCode = 500
                };
            }
        }
        #endregion

        #region 刷新access_token
        /// <summary>
        /// 刷新access_token
        /// </summary>
        /// <returns></returns>
        public AccessTokenModel RefreshAccessToken()
        {
            var config = this.Config.GetConfig(WeChatType.OfficeAccount);
            var result = new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={config.AppID}&grant_type=refresh_token&refresh_token={this.AccessToken.RefreshToken}"
            }.GetResponse();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return this.AccessToken = result.Html.JsonToObject<AccessTokenModel>();
            }
            else
            {
                return new AccessTokenModel
                {
                    ErrMsg = "请求出错.",
                    ErrCode = 500
                };
            }
        }
        #endregion

        #region 拉取用户信息(需scope为 snsapi_userinfo)
        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="openId">用户的唯一标识</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public UserInfoModel GetUserInfo(string openId, string lang = "zh_CN")
        {
            var result = new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"https://api.weixin.qq.com/sns/userinfo?access_token={this.AccessToken.AccessToken}&openid={openId}&lang={lang}"
            }.GetResponse();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.Html.JsonToObject<UserInfoModel>();
            }
            else
            {
                return new UserInfoModel
                {
                    ErrMsg = "请求出错.",
                    ErrCode = 500
                };
            }
        }
        #endregion

        #region 检验授权凭证（access_token）是否有效
        /// <summary>
        /// 检验授权凭证（access_token）是否有效
        /// </summary>
        /// <param name="accessToken">网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同</param>
        /// <param name="openId">用户的唯一标识</param>
        /// <returns></returns>
        public Boolean CheckAccessToken(string accessToken, string openId)
        {
            var result = new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $" https://api.weixin.qq.com/sns/auth?access_token={accessToken}&openid={openId}"
            }.GetResponse();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return result.Html.JsonToObject<BaseResult>().ErrCode == 0;
            return false;
        }
        #endregion

        #endregion
    }
}