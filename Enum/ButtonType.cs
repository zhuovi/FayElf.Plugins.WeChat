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
*  Create Time : 2022-03-16 10:57:56                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 自定义菜单类型
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        unknow = 0,
        /// <summary>
        /// 网页类型
        /// </summary>
        [Description("网页类型")]
        view = 1,
        /// <summary>
        /// 点击类型
        /// </summary>
        [Description("点击类型")]
        click = 2,
        /// <summary>
        /// 小程序类型
        /// </summary>
        [Description("小程序类型")]
        miniprogram = 3,
        /// <summary>
        /// 扫码带提示
        /// </summary>
        [Description("扫码带提示")]
        scancode_waitmsg = 4,
        /// <summary>
        /// 扫码推事件
        /// </summary>
        [Description("扫码推事件")]
        scancode_push = 5,
        /// <summary>
        /// 系统拍照发图
        /// </summary>
        [Description("系统拍照发图")]
        pic_sysphoto = 6,
        /// <summary>
        /// 拍照或者相册发图
        /// </summary>
        [Description("拍照或者相册发图")]
        pic_photo_or_album = 7,
        /// <summary>
        /// 微信相册发图
        /// </summary>
        [Description("微信相册发图")]
        pic_weixin = 8,
        /// <summary>
        /// 发送位置
        /// </summary>
        [Description("发送位置")]
        location_select = 9,
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        media_id = 10,
        /// <summary>
        /// 图文消息
        /// </summary>
        [Description("图文消息")]
        view_limited = 11,
        /// <summary>
        /// 发布后的图文消息
        /// </summary>
        [Description("发布后的图文消息")]
        article_id = 12,
        /// <summary>
        /// 发布后的图文消息
        /// </summary>
        [Description("发布后的图文消息")]
        article_view_limited = 13
    }
}