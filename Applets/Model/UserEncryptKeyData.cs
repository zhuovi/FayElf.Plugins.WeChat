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
*  Create Time : 2022-11-02 16:56:58                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Applets.Model
{
    /// <summary>
    /// 用户encryptKey
    /// </summary>
    public class UserEncryptKeyData:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserEncryptKeyData()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 用户最近三次的加密 key 列表
        /// </summary>
        [JsonElement("key_info_list")]
        public List<KeyInfoModel> KeyInfoList { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 加密 key
    /// </summary>
    public class KeyInfoModel {
        /// <summary>
        /// 加密key
        /// </summary>
        [JsonElement("encrypt_key")]
        [Description("加密key")]
        public string EncryptKey { get; set; }
        /// <summary>
        /// key的版本号
        /// </summary>
        [JsonElement("version")]
        [Description("key的版本号")]
        public string Version { get; set; }
        /// <summary>
        /// 剩余有效时间
        /// </summary>
        [JsonElement("expire_in")]
        [Description("剩余有效时间")]
        public int ExpireIn { get; set; }
        /// <summary>
        /// 加密iv
        /// </summary>
        [JsonElement("iv")]
        [Description("加密iv")]
        public string IV { get; set; }
        /// <summary>
        /// 创建 key 的时间戳
        /// </summary>
        [JsonElement("create_time")]
        [Description("创建 key 的时间戳")]
        public string CreateTime { get; set; }
    }
}