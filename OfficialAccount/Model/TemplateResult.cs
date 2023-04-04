using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 17:39:57                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 私人模板结果
    /// </summary>
    public class TemplateResult:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public TemplateResult()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 个人模板列表
        /// </summary>
        public TemplateData data { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 模板信息
    /// </summary>
    public class TemplateData
    {
        /// <summary>
        /// 添加至帐号下的模板 id，发送订阅通知时所需
        /// </summary>
        public string priTmplId { get; set; }
        /// <summary>
        /// 模版标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 模版内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 模板内容示例
        /// </summary>
        public string example { get; set; }
        /// <summary>
        /// 模版类型，2 为一次性订阅，3 为长期订阅
        /// </summary>
        public int type { get; set; }
    }
}