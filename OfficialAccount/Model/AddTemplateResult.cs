using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 14:40:26                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 添加模板返回结果
    /// </summary>
    public class AddTemplateResult:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public AddTemplateResult()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 添加至帐号下的模板id，发送订阅通知时所需
        /// </summary>
        public string priTmplId { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}