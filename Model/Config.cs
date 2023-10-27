using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XiaoFeng;
using XiaoFeng.Config;

/****************************************************************
*  Copyright © (2021) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2021-12-22 14:14:25                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    [ConfigFile("/Config/WeChatConfig.json", 0, "FAYELF-CONFIG-WeChatConfig", XiaoFeng.ConfigFormat.Json)]
    public class Config: ConfigSet<Config>
    {
        /// <summary>
        /// Token
        /// </summary>
        [Description("Token")]
        public string Token { get; set; } = "";
        /// <summary>
        /// 加密key
        /// </summary>
        [Description("EncodingAESKey")]
        public string EncodingAESKey { get; set; } = "";
        /// <summary>
        /// 私钥
        /// </summary>
        [Description("私钥")] 
        public string PartnerKey { set; get; } = "";
        /// <summary>
        /// 商户ID
        /// </summary>
        [Description("商户ID")] 
        public string MchID { set; get; } = "";
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
        /// <summary>
        /// 是否调试
        /// </summary>
        public bool Debug { get; set; } = true;
        /// <summary>
        /// 公众号配置
        /// </summary>
        [Description("公众号配置")]
        public WeChatConfig OfficeAccount { get; set; } = new WeChatConfig();
        /// <summary>
        /// 小程序配置
        /// </summary>
        [Description("小程序配置")]
        public WeChatConfig Applets { get; set; } = new WeChatConfig();
        /// <summary>
        /// 开放平台配置
        /// </summary>
        [Description("开放平台配置")]
        public WeChatConfig OpenPlatform { get; set; } = new WeChatConfig();
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="weChatType">配置类型</param>
        /// <returns></returns>
        public WeChatConfig GetConfig(WeChatType weChatType = WeChatType.OfficeAccount)
        {
            var config = this[weChatType.ToString()] as WeChatConfig;
            if (config == null) return new WeChatConfig
            {
                AppID = this.AppID,
                AppSecret = this.AppSecret
            };
            else
                return config;
        }
        #region 写日志
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg">消息</param>
        public void WriteLog(string msg)
        {
            if (this.Debug)
                LogHelper.Debug(msg);
        }
        #endregion
    }
}