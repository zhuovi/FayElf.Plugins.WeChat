using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-16 15:21:40                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 参数二维类型
    /// </summary>
    public enum QrcodeType
    {
        /// <summary>
        /// 临时二维码
        /// </summary>
        [Description("临时二维码")]
        QR_STR_SCENE = 0,
        /// <summary>
        /// 永久二维码
        /// </summary>
        [Description("永久二维码")]
        QR_LIMIT_STR_SCENE = 1
    }
}