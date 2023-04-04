using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng;
using XiaoFeng.Xml;
using System.Xml.Serialization;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-16 09:52:53                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.Model
{
    /// <summary>
    /// 图文模板类型
    /// </summary>
    [XmlRoot("Articles")]
    public class NewsModel
    {
        /// <summary>
        /// 列表
        /// </summary>
        [XmlElement("item")]
        public List<ArticleModel> Item { get; set; }
    }
    /// <summary>
    /// 图文模型
    /// </summary>
    public class ArticleModel : EntityBase
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public ArticleModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 图文消息标题
        /// </summary>
        [Description("图文消息标题")]
        [XmlCData]
        public string Title { get; set; }
        /// <summary>
        /// 图文消息描述
        /// </summary>
        [Description("图文消息描述")]
        [XmlCData] 
        public string Description { get; set; }
        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        [Description("图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200")]
        [XmlCData] 
        public string PicUrl { get; set; }
        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        [Description("点击图文消息跳转链接")]
        [XmlCData] 
        public string Url { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}