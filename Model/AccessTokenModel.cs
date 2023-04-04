using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-16 14:42:36                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// AuthAPI AccessToken 返回模型
    /// </summary>
    public class AccessTokenModel:AccessTokenData
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public AccessTokenModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        [Description("用户刷新access_token")]
        [JsonElement("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        [Description("用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID")]
        [JsonElement("openid")]
        public string OpenID { get; set; }
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        [Description("用户授权的作用域，使用逗号（,）分隔")]
        [JsonElement("scope")] 
        public string Scope { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}