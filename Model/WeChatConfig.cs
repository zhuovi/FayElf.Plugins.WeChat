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
*  Create Time : 2022-12-24 10:01:45                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeChatConfig
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public WeChatConfig()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// AppID
        /// </summary>
        [Description("AppID")]
        public string AppID { get; set; } = "";
        /// <summary>
        /// 密钥
        /// </summary>
        [Description("密钥")]
        public string AppSecret { get; set; } = "";
        #endregion

        #region 方法

        #endregion
    }
}