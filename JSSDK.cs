using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng;
using XiaoFeng.Cache;
using XiaoFeng.Http;
/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-10-27 15:43:12                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// JS SDK
    /// </summary>
    public class JSSDK
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public JSSDK()
        {
            this.Config = Config.Current;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 配置
        /// </summary>
        public Config Config { get; set; }
        #endregion

        #region 方法
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="url">请求网址</param>
        /// <returns></returns>
        public SignatureModel GetSignature(string url)
        {
            var model = new SignatureModel
            {
                Timestamp = DateTime.Now.ToTimeStamp(),
                AppId = this.Config.AppID,
                NonceString = RandomHelper.GetRandomString(16)
            };
            model.RawString = $"jsapi_ticket={this.GetJsApiTicket()}&noncestr={model.NonceString}&timestamp={model.Timestamp}&url={url}";
            model.Signature = model.RawString.SHA1Encrypt();
            return model;
        }
        /// <summary>
        /// 创建签名随机串
        /// </summary>
        /// <returns></returns>
        private string CreateNonceStr()
        {
            return RandomHelper.GetRandomString(16);
            int num = 16;
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string nonceStr = "";
            Random random = new Random();
            for (int index = 0; index < num; ++index)
                nonceStr += str.Substring(random.Next(0, str.Length - 1), 1);
            return nonceStr;
        }
        /// <summary>
        /// 获取JS票据
        /// </summary>
        /// <returns></returns>
        private string GetJsApiTicket()
        {
            var accessToken = Common.GetAccessToken(WeChatType.OfficeAccount);
            if (accessToken.ErrCode != 0) return accessToken.ErrMsg;

            var ticket = CacheHelper.Get<string>("Ticket-" + this.Config.AppID);
            if (ticket != null) return ticket;
            var result = new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{HttpApi.HOST}/cgi-bin/ticket/getticket?type=jsapi&access_token={accessToken.AccessToken}"
            }.GetResponse();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = result.Html.JsonToObject<JsApiTicket>();
                if (data != null && data.ErrCode == 0)
                {
                    CacheHelper.Set("Ticket-" + this.Config.AppID, data.Ticket, (data.ExpiresIn - 60) * 1000);
                    return data.Ticket;
                }
                else
                    return data?.ErrMsg;
            }
            return result.Html;
        }
        #endregion
    }
}