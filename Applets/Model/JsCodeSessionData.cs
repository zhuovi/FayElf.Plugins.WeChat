using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XiaoFeng.Json;
/****************************************************************
*  Copyright © (2021) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2021-12-22 14:38:11                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Applets.Model
{
    /// <summary>
    /// 登录凭证校验返回数据
    /// </summary>
    public class JsCodeSessionData : BaseResult
    {
        /// <summary>
        /// 无参构造器
        /// </summary>
        public JsCodeSessionData() { }

        /// <summary>
        /// 用户在开放平台的唯一标识符，若当前小程序已绑定到微信开放平台帐号下会返回
        /// </summary>
        [Description("用户在开放平台的唯一标识符，若当前小程序已绑定到微信开放平台帐号下会返回")]
        [JsonElement("unionid")]
        public string UnionID { get; set; }
        /// <summary>
        /// 会话密钥
        /// </summary>
        [Description("会话密钥")]
        [JsonElement("session_key")]
        public string SessionKey { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [Description("用户唯一标识")]
        [JsonElement("openid")]
        public string OpenID { get; set; }
    }
}