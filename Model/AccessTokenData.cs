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
*  Create Time : 2021-12-22 14:46:50                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 小程序全局唯一后台接口调用凭据
    /// </summary>
    public class AccessTokenData : BaseResult
    {
        /// <summary>
        /// 无参构造器
        /// </summary>
        public AccessTokenData() { }
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        [Description("获取到的凭证")]
        [JsonElement("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒。目前是7200秒之内的值。
        /// </summary>
        [Description("凭证有效时间，单位：秒。目前是7200秒之内的值。")]
        [JsonElement("expires_in")]
        public int ExpiresIn { get; set; }
    }
}