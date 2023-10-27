using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Xml;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-10-25 17:06:28                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Model
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VinceMessage : BaseMessage
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public VinceMessage()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 语音消息媒体id，可以调用获取临时素材接口拉取数据。
        /// </summary>
        [XmlCData]
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        [XmlCData]
        public string Format { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}