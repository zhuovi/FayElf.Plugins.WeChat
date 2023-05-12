using FayElf.Plugins.WeChat.Applets.Model;
using FayElf.Plugins.WeChat.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using XiaoFeng;
using XiaoFeng.Http;

/****************************************************************
*  Copyright © (2021) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2021-12-22 14:18:22                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Applets
{
    /// <summary>
    /// 小程序主类
    /// </summary>
    public class Applets
    {
        #region 无参构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public Applets()
        {
            this.Config = Config.Current;
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="config">配置</param>
        public Applets(Config config)
        {
            this.Config = config;
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="appID">AppID</param>
        /// <param name="appSecret">密钥</param>
        public Applets(string appID, string appSecret)
        {
            this.Config.AppID = appID;
            this.Config.AppSecret = appSecret;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 配置
        /// </summary>
        public Config Config { get; set; } = new Config();
        #endregion

        #region 方法

        #region 登录凭证校验
        /// <summary>
        /// 登录凭证校验
        /// </summary>
        /// <param name="code">登录时获取的 code</param>
        /// <returns></returns>
        public JsCodeSessionData JsCode2Session(string code)
        {
            var session = new JsCodeSessionData();
            var config = this.Config.GetConfig(WeChatType.Applets);
            var result = HttpHelper.GetHtml(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{HttpApi.HOST}/sns/jscode2session?appid={config.AppID}&secret={config.AppSecret}&js_code={code}&grant_type=authorization_code"
            });
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                session = result.Html.JsonToObject<JsCodeSessionData>();
            }
            else
            {
                session.ErrMsg = "请求出错.";
                session.ErrCode = 500;
            }
            return session;
        }
        #endregion

        #region 下发小程序和公众号统一的服务消息
        /// <summary>
        /// 下发小程序和公众号统一的服务消息
        /// </summary>
        /// <param name="data">下发数据</param>
        /// <returns></returns>
        public BaseResult UniformSend(UniformSendData data)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"{HttpApi.HOST}/cgi-bin/message/wxopen/template/uniform_send?access_token={token.AccessToken}",
                    BodyData = data.ToJson()
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<BaseResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                        {
                            {40037,"模板id不正确，weapp_template_msg.template_id或者mp_template_msg.template_id" },
                            {41028,"weapp_template_msg.form_id过期或者不正确" },
                            {41029,"weapp_template_msg.form_id已被使用" },
                            {41030,"weapp_template_msg.page不正确" },
                            {45009,"接口调用超过限额" },
                            {40003,"touser不是正确的openid" },
                            {40013,"appid不正确，或者不符合绑定关系要求" }
                        };
                        result.ErrMsg += "[" + dic[result.ErrCode] + "]";
                    }
                    return result;
                }
                else
                {
                    return new BaseResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求出错."
                    };
                }
            });
        }
        #endregion

        #region 获取用户手机号
        /// <summary>
        /// 获取用户手机号
        /// </summary>
        /// <param name="code">手机号获取凭证</param>
        /// <returns></returns>
        public UserPhoneData GetUserPhone(string code)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"{HttpApi.HOST}/wxa/business/getuserphonenumber?access_token={token.AccessToken}",
                    BodyData = $"{{\"code\":\"{code}\"}}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<UserPhoneData>();
                    if (result.ErrCode != 0)
                    {
                        result.ErrMsg += "[" + result.ErrCode + "]";
                    }
                    return result;
                }
                else
                {
                    return new UserPhoneData
                    {
                        ErrCode = 500,
                        ErrMsg = "请求出错."
                    };
                }
            });
        }
        #endregion

        #region 获取用户encryptKey
        /// <summary>
        /// 获取用户encryptKey
        /// </summary>
        /// <param name="session">Session数据</param>
        /// <returns></returns>
        public UserEncryptKeyData GetUserEncryptKey(JsCodeSessionData session)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"{HttpApi.HOST}/wxa/business/getuserencryptkey?access_token={token.AccessToken}",
                    BodyData = $"{{\"openid\":\"{session.OpenID}\",\"signature\":\"{"".HMACSHA256Encrypt(session.SessionKey)}\",\"sig_method\":\"hmac_sha256\"}}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<UserEncryptKeyData>();
                    if (result.ErrCode != 0)
                    {
                        result.ErrMsg += "[" + result.ErrCode + "]";
                    }
                    return result;
                }
                else
                {
                    return new UserEncryptKeyData
                    {
                        ErrCode = 500,
                        ErrMsg = "请求出错."
                    };
                }
            });
        }
        #endregion

        #region 获取小程序码
        /// <summary>
        /// 获取小程序码
        /// </summary>
        /// <param name="path">扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。</param>
        /// <param name="width">二维码的宽度，单位 px。默认值为430，最小 280px，最大 1280px</param>
        /// <param name="autoColor">默认值false；自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调</param>
        /// <param name="color">默认值{"r":0,"g":0,"b":0} ；auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示</param>
        /// <param name="ishyaline">背景是否透明</param>
        /// <returns></returns>
        public QrCodeResult GetQRCode(string path, int width, Boolean autoColor = false, Color? color = null, Boolean ishyaline = false)
        {
            if (!color.HasValue) color = Color.Black;
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var result = new HttpRequest
                {
                    Address = $"{HttpApi.HOST}/wxa/getwxacode?access_token={token.AccessToken}",
                    Method = HttpMethod.Post,
                    BodyData = $@"{{
""path"":""{path}"",
""width"":{width},
""auto_color"":{autoColor.ToString().ToLower()},
""line_color"":{{""r"":{color?.R},""g"":{color?.G},""b"":{color?.B}}},
""is_hyaline"":{ishyaline.ToString().ToLower()}
}}"
                }.GetResponse();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (result.Html.IndexOf("errcode") == -1)
                    {
                        return new QrCodeResult
                        {
                            ErrCode = 0,
                            ContentType = result.ContentType,
                            Buffer = result.Data.ToBase64String()
                        };
                    }
                }
                return new QrCodeResult
                {
                    ErrCode = 500,
                    ErrMsg = result.Html
                };
            });
        }
        #endregion

        #region 获取不限制的小程序码
        /// <summary>
        /// 获取不限制的小程序码
        /// </summary>
        /// <param name="page">默认是主页，页面 page，例如 pages/index/index，根路径前不要填加 /，不能携带参数（参数请放在 scene 字段里），如果不填写这个字段，默认跳主页面。</param>
        /// <param name="scene">最大32个可见字符，只支持数字，大小写英文以及部分特殊字符：!#$&'()*+,/:;=?@-._~，其它字符请自行编码为合法字符（因不支持%，中文无法使用 urlencode 处理，请使用其他编码方式）</param>
        /// <param name="checkPath">默认是true，检查page 是否存在，为 true 时 page 必须是已经发布的小程序存在的页面（否则报错）；为 false 时允许小程序未发布或者 page 不存在， 但page 有数量上限（60000个）请勿滥用。</param>
        /// <param name="envVersion">要打开的小程序版本。正式版为 "release"，体验版为 "trial"，开发版为 "develop"。默认是正式版。</param>
        /// <param name="width">默认430，二维码的宽度，单位 px，最小 280px，最大 1280px</param>
        /// <param name="autoColor">自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调，默认 false</param>
        /// <param name="color">默认是{"r":0,"g":0,"b":0} 。auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示</param>
        /// <param name="ishyaline">默认是false，是否需要透明底色，为 true 时，生成透明底色的小程序</param>
        /// <returns></returns>
        public QrCodeResult GetUnlimitedQRCode(string page, string scene, Boolean checkPath, AppletEnvVersion envVersion, int width, Boolean autoColor = false, Color? color = null, Boolean ishyaline = false)
        {
            if (!color.HasValue) color = Color.Black;
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var result = new HttpRequest
                {
                    Address = $"{HttpApi.HOST}/wxa/getwxacodeunlimit?access_token={token.AccessToken}",
                    Method = HttpMethod.Post,
                    BodyData = $@"{{
""page"":""{page}"",
""scene"":""{scene}"",
""check_path"":{checkPath.ToString().ToLower()},
""env_version"":""{envVersion.ToString().ToLower()}"",
""width"":{width},
""auto_color"":{autoColor.ToString().ToLower()},
""line_color"":{{""r"":{color?.R},""g"":{color?.G},""b"":{color?.B}}},
""is_hyaline"":{ishyaline.ToString().ToLower()}
}}"
                }.GetResponse();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (result.Html.IndexOf("errcode") == -1)
                    {
                        return new QrCodeResult
                        {
                            ErrCode = 0,
                            ContentType = result.ContentType,
                            Buffer = result.Data.ToBase64String()
                        };
                    }
                }
                return new QrCodeResult
                {
                    ErrCode = 500,
                    ErrMsg = result.Html
                };
            });
        }
        #endregion

        #region 获取小程序二维码
        /// <summary>
        /// 获取小程序二维码
        /// </summary>
        /// <param name="path">扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。</param>
        /// <param name="width">二维码的宽度，单位 px。最小 280px，最大 1280px;默认是430</param>
        /// <returns></returns>
        public QrCodeResult CreateQRCode(string path, int width)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var result = new HttpRequest
                {
                    Address = $"{HttpApi.HOST}/cgi-bin/wxaapp/createwxaqrcode?access_token={token.AccessToken}",
                    Method = HttpMethod.Post,
                    BodyData = $@"{{
""path"":""{path}"",
""width"":{width}
}}"
                }.GetResponse();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (result.Html.IndexOf("errcode") == -1)
                    {
                        return new QrCodeResult
                        {
                            ErrCode = 0,
                            ContentType = result.ContentType,
                            Buffer = result.Data.ToBase64String()
                        };
                    }
                }
                return new QrCodeResult
                {
                    ErrCode = 500,
                    ErrMsg = result.Html
                };
            });
        }
        #endregion

        #endregion
    }
}