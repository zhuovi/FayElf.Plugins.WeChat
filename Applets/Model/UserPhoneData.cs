using System;
using System.Collections.Generic;
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
*  Create Time : 2022-11-02 16:26:28                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Applets.Model
{
    /// <summary>
    /// 用户手机模型
    /// </summary>
    public class UserPhoneData: BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserPhoneData()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 手机号信息
        /// </summary>
        [JsonElement("phone_info")]
        public UserInfo UserInfo { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 用户信息模型
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户绑定的手机号（国外手机号会有区号）
        /// </summary>
        [JsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 没有区号的手机号
        /// </summary>
        [JsonElement("purePhoneNumber")]
        public string PurePhoneNumber { get; set; }
        /// <summary>
        /// 区号
        /// </summary>
        [JsonElement("countryCode")]
        public string CountryCode { get; set; }
        /// <summary>
        /// 数据水印
        /// </summary>
        [JsonElement("watermark")]
        public Dictionary<string,string> Watermark { get; set; }
    }
}