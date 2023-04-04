using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng;
using XiaoFeng.Json;
using System.ComponentModel;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 14:00:04                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Applets.Model
{
    /// <summary>
    /// 统一下发模板接口
    /// </summary>
    public class UniformSendData
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 用户openid，可以是小程序的openid，也可以是mp_template_msg.appid对应的公众号的openid
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 公众号模板消息
        /// </summary>
        public MPTemplateMsg mp_template_msg { get; set; }
    }
    /// <summary>
    /// 公众号模板消息相关的信息，可以参考公众号模板消息接口
    /// </summary>
    public class MPTemplateMsg
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public MPTemplateMsg()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 公众号appid，要求与小程序有绑定且同主体
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 公众号模板id
        /// </summary>
        public string template_id { get; set; }
        /// <summary>
        /// 公众号模板消息所要跳转的url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 公众号模板消息所要跳转的小程序，小程序的必须与公众号具有绑定关系
        /// </summary>
        [OmitEmptyNode]
        public MiniProgram miniprogram { get; set; }
        /// <summary>
        /// 公众号模板消息的数据
        /// </summary>
        public Dictionary<string,ValueColor> data { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}