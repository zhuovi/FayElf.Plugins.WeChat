using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-18 11:50:56                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 行业分类模型
    /// </summary>
    public class IndustryModelResult:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public IndustryModelResult()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 帐号设置的主营行业
        /// </summary>
        [Description("帐号设置的主营行业")]
        [JsonElement("primary_industry")]
        public IndustryCategoryModel PrimaryIndustry { get; set; }
        /// <summary>
        /// 帐号设置的副营行业
        /// </summary>
        [Description("帐号设置的副营行业")]
        [JsonElement("secondary_industry")]
        public IndustryCategoryModel SecondaryIndustry { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 分类
    /// </summary>
    public class IndustryCategoryModel
    {
        /// <summary>
        /// 主分类
        /// </summary>
        [Description("主分类")]
        [JsonElement("first_class")]
        public string FirstClass { get; set; }
        /// <summary>
        /// 子分类
        /// </summary>
        [Description("子分类")]
        [JsonElement("second_class")]
        public string SecondClass { get; set; }
    }
}