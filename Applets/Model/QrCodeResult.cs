using System;
using System.Collections.Generic;
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
*  Create Time : 2022-11-14 14:38:52                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Applets.Model
{
    /// <summary>
    /// 二维码返回结果
    /// </summary>
    public class QrCodeResult:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public QrCodeResult()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 内容类型
        /// </summary>
        [JsonElement("contentType")]
        public string ContentType { get; set; }
        /// <summary>
        /// Buffer
        /// </summary>
        [JsonElement("buffer")]
        public string Buffer { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}