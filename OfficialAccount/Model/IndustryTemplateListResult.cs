using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Json;
using System.ComponentModel;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-18 12:03:44                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 行业模板列表
    /// </summary>
    public class IndustryTemplateListResult:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public IndustryTemplateListResult()
        {

        }
        #endregion

        #region 属性
        /*
         * {	
     "template_list": [{
      "template_id": "iPk5sOIt5X_flOVKn5GrTFpncEYTojx6ddbt8WYoV5s",
      "title": "领取奖金提醒",
      "primary_industry": "IT科技",
      "deputy_industry": "互联网|电子商务",
      "content": "{ {result.DATA} }\n\n领奖金额:{ {withdrawMoney.DATA} }\n领奖  时间:    { {withdrawTime.DATA} }\n银行信息:{ {cardInfo.DATA} }\n到账时间:  { {arrivedTime.DATA} }\n{ {remark.DATA} }",
      "example": "您已提交领奖申请\n\n领奖金额：xxxx元\n领奖时间：2013-10-10 12:22:22\n银行信息：xx银行(尾号xxxx)\n到账时间：预计xxxxxxx\n\n预计将于xxxx到达您的银行卡"
   }]
}
         */
        /// <summary>
        /// 模板列表
        /// </summary>
        [Description("模板列表")]
        [JsonElement("template_list")]
        public List<IndustryTemplateListModel> TemplateList { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 行业模板模型
    /// </summary>
    public class IndustryTemplateListModel
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        [Description("模板ID"),JsonElement("template_id")]
        public string TemplateID { get; set; }
        /// <summary>
        /// 模板标题
        /// </summary>
        [Description("模板标题"), JsonElement("title")]
        public string Title { get; set; }
        /// <summary>
        /// 模板所属行业的一级行业
        /// </summary>
        [Description("模板所属行业的一级行业"), JsonElement("primary_industry")]
        public string PrimaryIndustry { get; set; }
        /// <summary>
        /// 模板所属行业的二级行业
        /// </summary>
        [Description("模板所属行业的二级行业"), JsonElement("deputy_industry")]
        public string DeputyIndustry { get; set; }
        /// <summary>
        /// 模板内容
        /// </summary>
        [Description("模板内容"), JsonElement("content")]
        public string Content { get; set; }
        /// <summary>
        /// 模板示例
        /// </summary>
        [Description("模板示例"), JsonElement("example")]
        public string Example { get; set; }
    }
}