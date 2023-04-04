using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-15 10:26:26                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        unknow = 0,
        /// <summary>
        /// 关注
        /// </summary>
        [Description("关注")]
        subscribe = 1,
        /// <summary>
        /// 取消关注
        /// </summary>
        [Description("取消关注")]
        unsubscribe = 2,
        /// <summary>
        /// 扫描带参数二维码事件
        /// </summary>
        [Description("扫描带参数二维码事件")]
        SCAN = 3,
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        [Description("上报地理位置事件")]
        LOCATION = 4,
        /// <summary>
        /// 点击菜单拉取消息时的事件推送
        /// </summary>
        [Description("点击菜单拉取消息时的事件推送")]
        CLICK = 5,
        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        [Description("点击菜单跳转链接时的事件推送")]
        VIEW = 6,
        /// <summary>
        /// 在模版消息发送任务完成后，微信服务器会将是否送达成功作为通知
        /// </summary>
        [Description("模板消息发送成功后的事件推送")]
        TEMPLATESENDJOBFINISH = 7,
        /// <summary>
        /// 资质认证成功
        /// </summary>
        [Description("资质认证成功")]
        qualification_verify_success = 8,
        /// <summary>
        /// 资质认证失败
        /// </summary>
        [Description("资质认证失败")]
        qualification_verify_fail = 9,
        /// <summary>
        /// 名称认证成功
        /// </summary>
        [Description("名称认证成功")]
        naming_verify_success = 10,
        /// <summary>
        /// 名称认证失败
        /// </summary>
        [Description("名称认证失败")]
        naming_verify_fail = 11,
        /// <summary>
        /// 年审通知
        /// </summary>
        [Description("年审通知")]
        annual_renew = 12,
        /// <summary>
        /// 用户操作订阅通知弹窗
        /// </summary>
        [Description("用户操作订阅通知弹窗")]
        subscribe_msg_popup_event = 13,
        /// <summary>
        /// 用户管理订阅通知
        /// </summary>
        [Description("用户管理订阅通知")]
        subscribe_msg_change_event = 14,
        /// <summary>
        /// 发送订阅通知
        /// </summary>
        [Description("发送订阅通知")]
        subscribe_msg_sent_event = 15,
        /// <summary>
        /// 事件推送发布结果
        /// </summary>
        [Description("事件推送发布结果")]
        PUBLISHJOBFINISH = 16,
        /// <summary>
        /// 授权用户资料变更
        /// </summary>
        [Description("授权用户资料变更")] 
        user_info_modified = 17
    }
}