using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-11 14:32:04                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 返回结果基类
    /// </summary>
    public class BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public BaseResult()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 错误码
        /// </summary>
        [Description("错误码")]
        [JsonElement("errcode")] 
        public int ErrCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [Description("错误信息")]
        [JsonElement("errmsg")] 
        public string ErrMsg { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}