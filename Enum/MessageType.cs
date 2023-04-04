using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XiaoFeng;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-15 09:11:00                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        unknown = 0,
        /// <summary>
        /// 文本消息
        /// </summary>
        [Description("文本消息")]
        text = 1,
        /// <summary>
        /// 图片消息
        /// </summary>
        [Description("图片消息")]
        image = 2,
        /// <summary>
        /// 语音消息
        /// </summary>
        [Description("语音消息")]
        voice = 3,
        /// <summary>
        /// 视频消息
        /// </summary>
        [Description("视频消息")]
        video = 4,
        /// <summary>
        /// 小视频消息
        /// </summary>
        [Description("小视频消息")]
        shortvideo = 5,
        /// <summary>
        /// 地理位置消息
        /// </summary>
        [Description("地理位置消息")]
        location = 6,
        /// <summary>
        /// 链接消息
        /// </summary>
        [Description("链接消息")]
        link = 7,
        /// <summary>
        /// 事件
        /// </summary>
        [Description("事件")]
        [EnumName("event")]
        Event = 8,
        /// <summary>
        /// 音乐
        /// </summary>
        [Description("音乐")]
        music = 9,
        /// <summary>
        /// 图文消息
        /// </summary>
        [Description("图文消息")]
        news = 10
    }
}