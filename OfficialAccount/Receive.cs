using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.Xml;
using System.Xml;
using System.Xml.Serialization;
using XiaoFeng;
using XiaoFeng.IO;
using XiaoFeng.Cryptography;
using System.Linq;
using FayElf.Plugins.WeChat.Model;
using FayElf.Plugins.WeChat.Cryptotraphy;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-14 17:53:45                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount
{
    /// <summary>
    /// 微信接收操作类
    /// </summary>
    public class Receive
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public Receive()
        {
            this.Config = Config.Current;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 配置
        /// </summary>
        public Config Config { get; set; }
        #endregion

        #region 方法

        #region 对请求进行signature校验
        /// <summary>
        /// 对请求进行signature校验
        /// </summary>
        /// <returns></returns>
        public Boolean CheckSignature(string signature, string nonce, string timestamp,string token)
        {
            if (signature.IsNullOrEmpty() || nonce.IsNullOrEmpty() || timestamp.IsNullOrEmpty() || timestamp.IsNotMatch(@"^\d+$")) return false;
            Config.WriteLog($"signature:{signature},nonce:{nonce},timestamp:{timestamp},token:{token}");
            Config.WriteLog($"sign:{new string[] { token, nonce, timestamp }.OrderBy(a => a).Join("").SHA1Encrypt().ToLower()}");
            return new string[] { token, nonce, timestamp }.OrderBy(a => a).Join("").SHA1Encrypt().ToLower() == signature.ToLower();
        }
        #endregion

        #region 接收数据
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        public string RequestMessage(Microsoft.AspNetCore.Http.HttpRequest request, Func<BaseMessage?, XmlValue, string> func)
        {
            var encrypt_type = request.Query["encrypt_type"].ToString().ToUpper() == "AES";
            var signature = request.Query["signature"].ToString();
            var timestamp = request.Query["timestamp"].ToString();
            var nonce = request.Query["nonce"].ToString();
            var echostr = request.Query["echostr"].ToString();
            Config.WriteLog($"encrypt_type:{encrypt_type},signature:{signature},timestamp:{timestamp},nonce:{nonce},echostr:{echostr},token:{this.Config.Token}");
            if (request.Method == "GET")
            {
                
                return this.CheckSignature(signature, nonce, timestamp, this.Config.Token) ? echostr : "error";
            }
            var msg_signature = request.Query["msg_signature"].ToString();
            Config.WriteLog($"msg_signature:{msg_signature}");
            var msg = request.Body.ReadToEnd();
            Config.WriteLog(msg);
            if (encrypt_type)
            {
                var wxBizMsgCrypt = new WXBizMsgCrypt(this.Config.Token, this.Config.EncodingAESKey, this.Config.AppID);
                var _msg = "";
                var ret = wxBizMsgCrypt.DecryptMsg(msg_signature, timestamp, nonce, msg, ref _msg);
                if (ret != 0)//解密失败
                {
                    //TODO：开发者解密失败的业务处理逻辑
                    Config.WriteLog($"微信公众号数据解密失败.[decrypt message return {ret}, request body {msg}]");
                }
                msg = _msg;
            }
            var data = msg.XmlToEntity() as XmlValue;
            if (data == null || data.ChildNodes == null || data.ChildNodes.Count < 1) return "";
            var xml = data.ChildNodes.First();
            var BaseMsg = xml.ToObject(typeof(BaseMessage)) as BaseMessage;
            var message =  func.Invoke(BaseMsg, xml);
            if (encrypt_type)
            {
                var _msg = "";
                var wxBizMsgCrypt = new WXBizMsgCrypt(this.Config.Token, this.Config.EncodingAESKey, this.Config.AppID);
                var ret = wxBizMsgCrypt.EncryptMsg(message, timestamp, nonce, ref _msg);
                if (ret != 0)//加密失败
                {
                    //TODO：开发者加密失败的业务处理逻辑
                    Config.WriteLog($"微信公众号数据加密失败.[encrypt message return {ret}, response body {message}]");
                }
                message= _msg;
            }
            return message;
        }
        #endregion

        #region 输出内容
        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="messageType">内容类型</param>
        /// <param name="fromUserName">发送方帐号</param>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="func">委托</param>
        /// <returns></returns>
        private string ReplayContent(MessageType messageType, string fromUserName, string toUserName, Func<string> func) => $"<xml><ToUserName><![CDATA[{toUserName}]]></ToUserName><FromUserName><![CDATA[{fromUserName}]]></FromUserName><CreateTime>{DateTime.Now.ToTimeStamp()}</CreateTime><MsgType><![CDATA[{messageType.GetEnumName()}]]></MsgType>{func.Invoke()}</xml>";
        #endregion

        #region 输出文本消息
        /// <summary>
        /// 输出文本消息
        /// </summary>
        /// <param name="fromUserName">发送方帐号</param>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="content">回复内容</param>
        /// <returns></returns>
        public string ReplayText(string fromUserName, string toUserName, string content) => this.ReplayContent(MessageType.text, fromUserName, toUserName, () => $"<Content><![CDATA[{content}]]></Content>");
        #endregion

        #region 回复图片
        /// <summary>
        /// 回复图片
        /// </summary>
        /// <param name="fromUserName">发送方帐号</param>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="mediaId">通过素材管理中的接口上传多媒体文件，得到的id</param>
        /// <returns></returns>
        public string ReplayImage(string fromUserName, string toUserName, string mediaId) => this.ReplayContent(MessageType.image, fromUserName, toUserName, () => $"<Image><MediaId><![CDATA[{mediaId}]]></MediaId></Image>");
        #endregion

        #region 回复语音消息
        /// <summary>
        /// 回复语音消息
        /// </summary>
        /// <param name="fromUserName">发送方帐号</param>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="mediaId">通过素材管理中的接口上传多媒体文件，得到的id</param>
        /// <returns></returns>
        public string ReplayVoice(string fromUserName, string toUserName, string mediaId) => this.ReplayContent(MessageType.voice, fromUserName, toUserName, () => $"<Voice><MediaId><![CDATA[{mediaId}]]></MediaId></Voice>");
        #endregion

        #region 回复视频消息
        /// <summary>
        /// 回复视频消息
        /// </summary>
        /// <param name="fromUserName">发送方帐号</param>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="mediaId">通过素材管理中的接口上传多媒体文件，得到的id</param>
        /// <param name="title">视频消息的标题</param>
        /// <param name="description">视频消息的描述</param>
        /// <returns></returns>
        public string ReplayVideo(string fromUserName, string toUserName, string mediaId, string title, string description) => this.ReplayContent(MessageType.video, fromUserName, toUserName, () => $"<Video><MediaId><![CDATA[{mediaId}]]></MediaId><Title><![CDATA[{title}]]></Title><Description><![CDATA[{description}]]></Description></Video>");
        #endregion

        #region 回复音乐消息
        /// <summary>
        /// 回复视频消息
        /// </summary>
        /// <param name="fromUserName">发送方帐号</param>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="title">视频消息的标题</param>
        /// <param name="description">视频消息的描述</param>
        /// <param name="musicUrl">音乐链接</param>
        /// <param name="HQmusicUrl">高质量音乐链接，WIFI环境优先使用该链接播放音乐</param>
        /// <param name="mediaId">通过素材管理中的接口上传多媒体文件，得到的id</param>
        /// <returns></returns>
        public string ReplayMusic(string fromUserName, string toUserName, string title, string description, string mediaId,string musicUrl,string HQmusicUrl) => this.ReplayContent(MessageType.music, fromUserName, toUserName, () => $"<Music><Title><![CDATA[{title}]]></Title><Description><![CDATA[{description}]]></Description><MusicUrl><![CDATA[{musicUrl}]]></MusicUrl><HQMusicUrl><![CDATA[{HQmusicUrl}]]></HQMusicUrl><ThumbMediaId><![CDATA[{mediaId}]]></ThumbMediaId></Music>");
        #endregion

        #region 回复图文消息
        /// <summary>
        /// 回复图文消息
        /// </summary>
        /// <param name="fromUserName">发送方帐号</param>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="list">图文列表</param>
        /// <returns></returns>
        public string ReplayNews(string fromUserName, string toUserName, NewsModel news) => this.ReplayContent(MessageType.news, fromUserName, toUserName, () =>
          {
              if (news == null || news.Item == null || news.Item.Count == 0) return "";
              return $"<ArticleCount>{news.Item.Count}</ArticleCount>{news.EntityToXml(OmitXmlDeclaration: true, OmitComment: true, Indented: false)}";
          });
        #endregion

        #endregion
    }
}