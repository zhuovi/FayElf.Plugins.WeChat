using System;
using System.Collections.Generic;
using System.Text;
using FayElf.Plugins.WeChat.OfficialAccount.Model;
using XiaoFeng;
using XiaoFeng.Http;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 09:34:31                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount
{
    /// <summary>
    /// 订阅通知操作类
    /// </summary>
    public class Subscribe
    {
        #region 无参构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public Subscribe()
        {
            this.Config = Config.Current;
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="config">配置</param>
        public Subscribe(Config config)
        {
            this.Config = config;
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="appID">AppID</param>
        /// <param name="appSecret">密钥</param>
        public Subscribe(string appID, string appSecret)
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

        #region 选用模板
        /// <summary>
        /// 选用模板
        /// </summary>
        /// <param name="tid">模板标题 id，可通过getPubTemplateTitleList接口获取，也可登录公众号后台查看获取</param>
        /// <param name="kidList">开发者自行组合好的模板关键词列表，关键词顺序可以自由搭配（例如 [3,5,4] 或 [4,5,3]），最多支持5个，最少2个关键词组合</param>
        /// <param name="sceneDesc">服务场景描述，15个字以内</param>
        /// <returns></returns>
        public AddTemplateResult AddTemplate(string tid, int kidList, string sceneDesc)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"https://api.weixin.qq.com/wxaapi/newtmpl/addtemplate?access_token={token.AccessToken}",
                    BodyData = new
                    {
                        access_token = token.AccessToken,
                        tid = tid,
                        kidList = kidList,
                        sceneDesc = sceneDesc
                    }.ToJson()
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<AddTemplateResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                    {
                        {200011,"此账号已被封禁，无法操作" },
                        {200012,"私有模板数已达上限，上限 50 个" },
                        {200013,"此模版已被封禁，无法选用" },
                        {200014,"模版 tid 参数错误" },
                        {200020,"关键词列表 kidList 参数错误" },
                        {200021,"场景描述 sceneDesc 参数错误" }
                    };
                        result.ErrMsg += "[" + dic[result.ErrCode] + "]";
                    }
                    return result;
                }
                else
                {
                    return new AddTemplateResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 删除模板
        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="priTmplId">要删除的模板id</param>
        /// <returns></returns>
        public BaseResult DeleteTemplate(string priTmplId)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"https://api.weixin.qq.com/wxaapi/newtmpl/deltemplate?access_token={token.AccessToken}",
                    BodyData = $@"{{priTmplId:""{priTmplId}""}}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<AddTemplateResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                        {
                            {20001,"系统错误（包含该账号下无该模板等）" },
                            {20002,"参数错误" },
                            {200014,"模版 tid 参数错误" }
                        };
                        result.ErrMsg += "[" + dic[result.ErrCode] + "]";
                    }
                    return result;
                }
                else
                {
                    return new AddTemplateResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 获取公众号类目
        /// <summary>
        /// 获取公众号类目
        /// </summary>
        /// <returns></returns>
        public TemplateCategoryResult GetCategory()
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Get,
                    Address = $"https://api.weixin.qq.com/wxaapi/newtmpl/getcategory?access_token={token.AccessToken}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<TemplateCategoryResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                        {
                            {20001,"系统错误（包含该账号下无该模板等）" },
                            {20002,"参数错误" },
                            {200014,"模版 tid 参数错误" }
                        };
                        result.ErrMsg += "[" + dic[result.ErrCode] + "]";
                    }
                    return result;
                }
                else
                {
                    return new TemplateCategoryResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }

        #endregion

        #region 获取模板中的关键词
        /// <summary>
        /// 获取模板中的关键词
        /// </summary>
        /// <param name="tid">模板标题 id，可通过接口获取</param>
        /// <returns></returns>
        public TemplateKeywordResult GetPubTemplateKeyWordsById(string tid)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Get,
                    Address = $"https://api.weixin.qq.com/wxaapi/newtmpl/getpubtemplatekeywords?access_token={token.AccessToken}&tid={tid}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<TemplateKeywordResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                        {
                            {20001,"系统错误" }
                        };
                        result.ErrMsg += "[" + dic[result.ErrCode] + "]";
                    }
                    return result;
                }
                else
                {
                    return new TemplateKeywordResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 获取类目下的公共模板
        /// <summary>
        /// 获取类目下的公共模板
        /// </summary>
        /// <param name="ids">类目 id，多个用逗号隔开</param>
        /// <param name="start">用于分页，表示从 start 开始，从 0 开始计数</param>
        /// <param name="limit">用于分页，表示拉取 limit 条记录，最大为 30</param>
        /// <returns></returns>
        public PubTemplateResult GetPubTemplateTitleList(string ids, int start, int limit)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Get,
                    Address = $@"https://api.weixin.qq.com/wxaapi/newtmpl/getpubtemplatetitles?access_token={token.AccessToken}&ids=""{ids}""&start={start}&limit={limit}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<PubTemplateResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                        {
                            {20001,"系统错误" }
                        };
                        result.ErrMsg += "[" + dic[result.ErrCode] + "]";
                    }
                    return result;
                }
                else
                {
                    return new PubTemplateResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 获取私有模板列表
        /// <summary>
        /// 获取私有模板列表
        /// </summary>
        /// <returns></returns>
        public TemplateResult GetTemplateList()
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Get,
                    Address = $"https://api.weixin.qq.com/wxaapi/newtmpl/gettemplate?access_token={token.AccessToken}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<TemplateResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                        {
                            {20001,"系统错误" }
                        };
                        result.ErrMsg += "[" + dic[result.ErrCode] + "]";
                    }
                    return result;
                }
                else
                {
                    return new TemplateResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 发送订阅通知
        /// <summary>
        /// 发送订阅通知
        /// </summary>
        /// <param name="touser">接收者（用户）的 openid</param>
        /// <param name="template_id">所需下发的订阅模板id</param>
        /// <param name="page">跳转网页时填写</param>
        /// <param name="miniprogram">跳转小程序时填写，格式如{ "appid": "", "pagepath": { "value": any } }</param>
        /// <param name="data">模板内容，格式形如 { "key1": { "value": any }, "key2": { "value": any } }</param>
        /// <returns></returns>
        public BaseResult Send(string touser, string template_id, string page, MiniProgram miniprogram, Dictionary<string, ValueColor> data)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var _data = new Dictionary<string, object>()
                {
                    {"touser",touser },
                    {"template_id",template_id}
                };
                if (page.IsNotNullOrEmpty())
                    _data.Add("page", page);
                if (miniprogram != null)
                    _data.Add("mimiprogram", miniprogram);
                _data.Add("data", data);

                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/bizsend?access_token={token.AccessToken}",
                    BodyData = _data.ToJson()
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Html.JsonToObject<BaseResult>();
                    if (result.ErrCode != 0)
                    {
                        var dic = new Dictionary<int, string>
                        {
                            {40003,"touser字段openid为空或者不正确" },
                            {40037,"订阅模板id为空不正确" },
                            {43101,"用户拒绝接受消息，如果用户之前曾经订阅过，则表示用户取消了订阅关系" },
                            {47003,"模板参数不准确，可能为空或者不满足规则，errmsg会提示具体是哪个字段出错" },
                            {41030,"page路径不正确" },
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
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #endregion
    }

}