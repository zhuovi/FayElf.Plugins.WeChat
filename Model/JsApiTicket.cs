using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-10-27 15:56:38                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// JsApi 
    /// </summary>
    public class JsApiTicket
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public JsApiTicket()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonElement("errcode")]
        public int ErrCode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonElement("errmsg")]
        public string ErrMsg { get; set; }
        /// <summary>
        /// 票据
        /// </summary>
        [JsonElement("ticket")]
        public string Ticket { get; set; }
        /// <summary>
        /// 过期时长
        /// </summary>
        [JsonElement("expires_in")]
        public int ExpiresIn { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}