using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 17:49:07                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 小程序跳转
    /// </summary>
    public class MiniProgram
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public MiniProgram()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 小程序APP ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 小程序页面路径
        /// </summary>
        public string pagepath { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}