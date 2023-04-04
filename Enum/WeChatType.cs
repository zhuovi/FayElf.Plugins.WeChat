using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-12-24 09:58:57                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 微信类型
    /// </summary>
    public enum WeChatType
    {
        /// <summary>
        /// 公众号
        /// </summary>
        [Description("公众号")]
        OfficeAccount = 0,
        /// <summary>
        /// 小程序
        /// </summary>
        [Description("小程序")]
        Applets = 1,
        /// <summary>
        /// 开放平台
        /// </summary>
        [Description("开放平台")]
        OpenPlatform = 2
    }
}