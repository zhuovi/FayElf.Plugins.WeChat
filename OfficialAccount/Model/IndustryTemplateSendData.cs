using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng;
using XiaoFeng.Json;
using System.ComponentModel;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-18 13:38:33                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 模板发送数据
    /// </summary>
    public class IndustryTemplateSendData
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public IndustryTemplateSendData()
        {

        }
        #endregion

        #region 属性
        /*
         * {
           "touser":"OPENID",
           "template_id":"ngqIpbwh8bUfcSsECmogfXcV14J0tQlEpBO27izEYtY",
           "url":"http://weixin.qq.com/download",  
           "miniprogram":{
             "appid":"xiaochengxuappid12345",
             "pagepath":"index?foo=bar"
           },          
           "data":{
                   "first": {
                       "value":"恭喜你购买成功！",
                       "color":"#173177"
                   },
                   "keyword1":{
                       "value":"巧克力",
                       "color":"#173177"
                   },
                   "keyword2": {
                       "value":"39.8元",
                       "color":"#173177"
                   },
                   "keyword3": {
                       "value":"2014年9月22日",
                       "color":"#173177"
                   },
                   "remark":{
                       "value":"欢迎再次购买！",
                       "color":"#173177"
                   }
           }
       }
         */
        /// <summary>
        /// 接收者openid
        /// </summary>
        [Description("接收者openid"),JsonElement("touser")]
        public string ToUser { get; set; }
        /// <summary>
        /// 模板ID
        /// </summary>
        [Description("模板ID"), JsonElement("template_id")]
        public string TemplateId { get; set; }
        /// <summary>
        /// 模板跳转链接（海外帐号没有跳转能力）
        /// </summary>
        [Description("模板跳转链接（海外帐号没有跳转能力）"), JsonElement("url"), OmitEmptyNode]
        public string Url { get; set; }
        /// <summary>
        /// 跳小程序所需数据，不需跳小程序可不用传该数据
        /// </summary>
        [Description("跳小程序所需数据"), JsonElement("miniprogram"), OmitEmptyNode]
        public MiniProgram miniprogram { get; set; }
        /// <summary>
        /// 模板数据
        /// </summary>
        [Description("模板数据"), JsonElement("data")] 
        public Dictionary<string, ValueColor> Data { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 发送数据返回结果
    /// </summary>
    public class IndustryTemplateSendDataResult : BaseResult
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [Description("消息ID"),JsonElement("msgid")]
        public string MsgID { get; set; }
    }
}