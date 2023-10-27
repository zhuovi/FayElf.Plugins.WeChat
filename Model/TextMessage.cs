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
*  Create Time : 2023-10-25 17:02:09                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Model
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessage : BaseMessage
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public TextMessage()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}