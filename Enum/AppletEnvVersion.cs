using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-11-14 15:19:02                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 小程序版本
    /// </summary>
    public enum AppletEnvVersion
    {
        /// <summary>
        /// 正式版
        /// </summary>
        RELEASE = 0,
        /// <summary>
        /// 体验版
        /// </summary>
        TRIAL = 1,
        /// <summary>
        /// 开发版
        /// </summary>
        DEVELOP = 2
    }
}