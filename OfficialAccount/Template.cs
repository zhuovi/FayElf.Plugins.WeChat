using FayElf.Plugins.WeChat.OfficialAccount.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng;
using XiaoFeng.Http;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-18 08:56:16                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount
{
    /// <summary>
    /// 模板消息操作类
    /// </summary>
    public class Template
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public Template()
        {
            this.Config = Config.Current;
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="config">配置</param>
        public Template(Config config)
        {
            this.Config = config;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 配置
        /// </summary>
        public Config Config { get; set; }
        #endregion

        #region 方法

        #region 设置所属行业
        /// <summary>
        /// 设置所属行业
        /// </summary>
        /// <param name="industry1">公众号模板消息所属行业编号</param>
        /// <param name="industry2">公众号模板消息所属行业编号</param>
        /// <returns></returns>
        public BaseResult SetIndustry(Industry industry1,Industry industry2)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method= HttpMethod.Post,
                    Address=$"https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token={token.AccessToken}",
                    BodyData = $@"{{""industry_id1"":""{(int)industry1}"",""industry_id2"":""{(int)industry2}""}}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<BaseResult>();
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

        #region 获取设置的行业信息
        /*
         * {
    "primary_industry":{"first_class":"运输与仓储","second_class":"快递"},
    "secondary_industry":{"first_class":"IT科技","second_class":"互联网|电子商务"}
}
         */
        /// <summary>
        /// 获取设置的行业信息
        /// </summary>
        /// <returns></returns>
        public IndustryModelResult GetIndustry()
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Get,
                    Address = $"https://api.weixin.qq.com/cgi-bin/template/get_industry?access_token={token.AccessToken}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<IndustryModelResult>();
                }
                else
                {
                    return new IndustryModelResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 获得模板ID
        /// <summary>
        /// 获得模板ID
        /// </summary>
        /// <param name="templateId">模板库中模板的编号，有“TM**”和“OPENTMTM**”等形式</param>
        /// <returns></returns>
        public IndustryTemplateResult AddTemplate(string templateId)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token={token.AccessToken}",
                    BodyData = $@"{{""template_id_short"":""{templateId}""}}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<IndustryTemplateResult>();
                }
                else
                {
                    return new IndustryTemplateResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 获取模板列表
        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <returns></returns>
        public IndustryTemplateListResult GetAllPrivateTemplate()
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Get,
                    Address = $"https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token={token.AccessToken}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<IndustryTemplateListResult>();
                }
                else
                {
                    return new IndustryTemplateListResult
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
        /// <param name="templateId">公众帐号下模板消息ID</param>
        /// <returns></returns>
        public Boolean DeletePrivateTemplate(string templateId)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            var result = Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={token.AccessToken}",
                    BodyData = $@"{{""template_id"":""{templateId}""}}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<BaseResult>();
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
            return result.ErrCode == 0;
        }
        #endregion

        #region 发送模板消息
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="data">发送数据</param>
        /// <returns></returns>
        public IndustryTemplateSendDataResult Send(IndustryTemplateSendData data)
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = HttpHelper.GetHtml(new HttpRequest
                {
                    Method = HttpMethod.Post,
                    Address = $"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={token.AccessToken}",
                    BodyData = data.ToJson()
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<IndustryTemplateSendDataResult>();
                }
                else
                {
                    return new IndustryTemplateSendDataResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求出错."
                    };
                }
            });
        }
        #endregion

        #endregion

    }
}