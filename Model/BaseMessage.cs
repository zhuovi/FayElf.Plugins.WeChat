using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng;
using XiaoFeng.Xml;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-15 09:07:49                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Model
{
    /// <summary>
    /// 接收回复公众号基础类
    /// </summary>
    public class BaseMessage : EntityBase
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public BaseMessage()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 接收方用户Open ID
        /// </summary>
        [XmlCData]
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方用户Open ID
        /// </summary>
        [XmlCData]
        public string FromUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public int CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [XmlCData, XmlConverter(typeof(StringEnumConverter))]
        public MessageType MsgType { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        [XmlCData, XmlConverter(typeof(StringEnumConverter))]
        public EventType Event { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        [XmlCData]
        public string MsgId { get; set; }
        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        [XmlCData]
        public string EventKey { get; set; }
        /// <summary>
        /// 消息的数据ID（消息如果来自文章时才有）
        /// </summary>
        public string MsgDataId { get; set; }
        /// <summary>
        /// 多图文时第几篇文章，从1开始（消息如果来自文章时才有）
        /// </summary>
        public string Idx { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}