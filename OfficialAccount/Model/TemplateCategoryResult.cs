using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 17:18:34                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// TemplateCategoryResult 类说明
    /// </summary>
    public class TemplateCategoryResult:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public TemplateCategoryResult()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 类目
        /// </summary>
        public List<TemplateCategory> data { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 模板类目
    /// </summary>
    public class TemplateCategory
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public int name { get; set; }
    }
}