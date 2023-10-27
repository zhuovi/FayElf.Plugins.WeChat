using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-10-27 15:44:55                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 签名模型
    /// </summary>
    public class SignatureModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public SignatureModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// Noice字符串
        /// </summary>
        public string NonceString { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public int Timestamp { get; set; }
        /// <summary>
        /// 原始字符串
        /// </summary>
        public string RawString { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}