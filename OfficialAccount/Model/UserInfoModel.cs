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
*  Create Time : 2022-03-16 14:57:50                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// 用户信息模型
    /// </summary>
    public class UserInfoModel:BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserInfoModel()
        {

        }
        #endregion

        #region 属性
        /*
         "openid": "OPENID",
  "nickname": NICKNAME,
  "sex": 1,
  "province":"PROVINCE",
  "city":"CITY",
  "country":"COUNTRY",
  "headimgurl":"https://thirdwx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/46",
  "privilege":[ "PRIVILEGE1" "PRIVILEGE2"     ],
  "unionid": "o6_bmasdasdsad6_2sgVt7hMZOPfL"
         */
        /// <summary>
        /// 用户的唯一标识
        /// </summary>
        [Description("用户的唯一标识")]
        [JsonElement("openid")]
        public string OpenID { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Description("用户昵称")]
        [JsonElement("nickname")]
        public string NickName { get; set; }
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        [Description("用户的性别，值为1时是男性，值为2时是女性，值为0时是未知")]
        [JsonElement("sex")]
        public string Sex { get; set; }
        /// <summary>
        /// 用户个人资料填写的省份
        /// </summary>
        [Description("用户个人资料填写的省份")]
        [JsonElement("province")]
        public string Province { get; set; }
        /// <summary>
        /// 普通用户个人资料填写的城市
        /// </summary>
        [Description("普通用户个人资料填写的城市")]
        [JsonElement("city")]
        public string City { get; set; }
        /// <summary>
        /// 国家，如中国为CN
        /// </summary>
        [Description("国家，如中国为CN")]
        [JsonElement("country")]
        public string Country { get; set; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        [Description("用户头像")]
        [JsonElement("headimgurl")]
        public string HeadImgurl { get; set; }
        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        [Description("用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）")]
        [JsonElement("privilege")]
        public string[] Privilege { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        [Description("只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。")]
        [JsonElement("unionid")]
        public string UnionID { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}