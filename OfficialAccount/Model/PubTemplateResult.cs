using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 17:34:03                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 子模板数据结果
    /// </summary>
    public class PubTemplateResult:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public PubTemplateResult()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 公共模板列表总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 模板标题列表
        /// </summary>
        public string data { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 子模板数据
    /// </summary>
    public class PubTemplate
    {
        /// <summary>
        /// 模版标题 id
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// 模版标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 模版类型，2 为一次性订阅，3 为长期订阅
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 模版所属类目 id
        /// </summary>
        public int categoryId { get; set; }
    }
}