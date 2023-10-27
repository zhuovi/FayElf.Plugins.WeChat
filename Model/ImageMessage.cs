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
*  Create Time : 2023-10-25 17:03:54                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Model
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessage : BaseMessage
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public ImageMessage()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 图片链接（由系统生成）
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片消息媒体id，可以调用获取临时素材接口拉取数据。
        /// </summary>
        [XmlCData]
        public string MediaId { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}