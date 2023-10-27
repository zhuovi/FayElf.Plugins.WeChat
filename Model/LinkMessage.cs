using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Xml;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-10-25 17:12:21                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Model
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class LinkMessage : BaseMessage
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public LinkMessage()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 消息标题
        /// </summary>
        [XmlCData]
        public string Title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        [XmlCData]
        public string Description { get; set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        [XmlCData]
        public string Url { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}