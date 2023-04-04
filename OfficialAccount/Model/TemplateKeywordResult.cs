using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 17:25:39                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 模板关键词返回结果
    /// </summary>
    public class TemplateKeywordResult : BaseResult
    {
        /// <summary>
        /// 公共模板列表总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 关键词列表
        /// </summary>
        public List<TemplateKeyword> data { get; set; }

    }
    /// <summary>
    /// 模板关键词
    /// </summary>
    public class TemplateKeyword
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public TemplateKeyword()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 关键词 id，选用模板时需要
        /// </summary>
        public int kid { get; set; }
        /// <summary>
        /// 关键词内容
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 关键词内容对应的示例
        /// </summary>
        public string example { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public string rule { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}