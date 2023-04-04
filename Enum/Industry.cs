using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-18 10:36:14                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat
{
    /// <summary>
    /// 行业配置
    /// </summary>
    public enum Industry
    {
        /// <summary>
        /// IT科技-互联网/电子商务
        /// </summary>
        [Description("IT科技-互联网/电子商务")]
        IT科技_互联网_电子商务=1,
        /// <summary>
        /// IT科技-IT软件与服务
        /// </summary>
        [Description("IT科技-IT软件与服务")]
        IT科技_IT软件与服务 = 2,
        /// <summary>
        /// IT科技-IT硬件与设备
        /// </summary>
        [Description("IT科技-IT硬件与设备")]
        IT科技_IT硬件与设备 = 3,
        /// <summary>
        /// IT科技-电子技术
        /// </summary>
        [Description("IT科技-电子技术")]
        IT科技_电子技术 = 4,
        /// <summary>
        /// IT科技-通信与运营商
        /// </summary>
        [Description("IT科技-通信与运营商")]
        IT科技_通信与运营商 = 5,
        /// <summary>
        /// IT科技-网络游戏
        /// </summary>
        [Description("IT科技-网络游戏")]
        IT科技_网络游戏 = 6,
        /// <summary>
        /// 金融业-银行
        /// </summary>
        [Description("金融业-银行")]
        金融业_银行 = 7,
        /// <summary>
        /// 金融业-基金理财信托
        /// </summary>
        [Description("金融业-基金理财信托")]
        金融业_基金理财信托 = 8,
        /// <summary>
        /// 金融业-保险
        /// </summary>
        [Description("金融业-保险")]
        金融业_保险 = 9,
        /// <summary>
        /// 餐饮-餐饮
        /// </summary>
        [Description("餐饮-餐饮")]
        餐饮_餐饮 = 10,
        /// <summary>
        /// 酒店旅游-酒店
        /// </summary>
        [Description("酒店旅游-酒店")]
        酒店旅游_酒店 = 11,
        /// <summary>
        /// 酒店旅游-旅游
        /// </summary>
        [Description("酒店旅游-旅游")]
        酒店旅游_旅游 = 12,
        /// <summary>
        /// 运输与仓储-快递
        /// </summary>
        [Description("运输与仓储-快递")]
        运输与仓储_快递 = 13,
        /// <summary>
        /// 运输与仓储-物流
        /// </summary>
        [Description("运输与仓储-物流")]
        运输与仓储_物流 = 14,
        /// <summary>
        /// 运输与仓储-仓储
        /// </summary>
        [Description("运输与仓储-仓储")]
        运输与仓储_仓储 = 15,
        /// <summary>
        /// 教育-培训
        /// </summary>
        [Description("教育-培训")]
        教育_培训 = 16,
        /// <summary>
        /// 教育-院校
        /// </summary>
        [Description("教育-院校")]
        教育_院校 = 17,
        /// <summary>
        /// 政府与公共事业-学术科研
        /// </summary>
        [Description("政府与公共事业-学术科研")]
        政府与公共事业_学术科研 = 18,
        /// <summary>
        /// 运输与仓储-交警
        /// </summary>
        [Description("政府与公共事业-交警")]
        政府与公共事业_交警 = 19,
        /// <summary>
        /// 政府与公共事业-博物馆
        /// </summary>
        [Description("政府与公共事业-博物馆")]
        政府与公共事业_博物馆 = 20,
        /// <summary>
        /// 政府与公共事业-公共事业非盈利机构
        /// </summary>
        [Description("政府与公共事业-公共事业非盈利机构")]
        政府与公共事业_公共事业非盈利机构 = 21,
        /// <summary>
        /// 医药护理-医药医疗
        /// </summary>
        [Description("医药护理-医药医疗")]
        医药护理_医药医疗 = 22,
        /// <summary>
        /// 医药护理-护理美容
        /// </summary>
        [Description("医药护理-护理美容")]
        医药护理_护理美容 = 23,
        /// <summary>
        /// 医药护理-保健与卫生
        /// </summary>
        [Description("医药护理-保健与卫生")]
        医药护理_保健与卫生 = 24,
        /// <summary>
        /// 交通工具-汽车相关
        /// </summary>
        [Description("交通工具-汽车相关")]
        交通工具_汽车相关 = 25,
        /// <summary>
        /// 医药护理-摩托车相关
        /// </summary>
        [Description("交通工具-摩托车相关")]
        交通工具_摩托车相关 = 26,
        /// <summary>
        /// 交通工具-火车相关
        /// </summary>
        [Description("交通工具-保火车相关")]
        交通工具_火车相关 = 27,
        /// <summary>
        /// 交通工具-飞机相关
        /// </summary>
        [Description("交通工具-飞机相关")]
        交通工具_飞机相关 = 28,
        /// <summary>
        /// 房地产-建筑
        /// </summary>
        [Description("医药护理-建筑")]
        房地产_建筑 = 29,
        /// <summary>
        /// 房地产-物业
        /// </summary>
        [Description("房地产-物业")]
        房地产_物业 = 30,
        /// <summary>
        /// 消费品-消费品
        /// </summary>
        [Description("消费品-消费品")]
        消费品_消费品 = 31,
        /// <summary>
        /// 商业服务-法律
        /// </summary>
        [Description("商业服务-法律")]
        商业服务_法律 = 32,
        /// <summary>
        /// 商业服务-会展
        /// </summary>
        [Description("商业服务-会展")]
        商业服务_会展 = 33,
        /// <summary>
        /// 商业服务-中介服务
        /// </summary>
        [Description("商业服务-中介服务")]
        商业服务_中介服务 = 34,
        /// <summary>
        /// 商业服务-认证
        /// </summary>
        [Description("商业服务-认证")]
        商业服务_认证 = 35,
        /// <summary>
        /// 商业服务-审计
        /// </summary>
        [Description("商业服务-审计")]
        商业服务_审计 = 36,
        /// <summary>
        /// 文体娱乐-传媒
        /// </summary>
        [Description("文体娱乐-传媒")]
        文体娱乐_传媒 = 37,
        /// <summary>
        /// 文体娱乐-体育
        /// </summary>
        [Description("文体娱乐-体育")]
        文体娱乐_体育 = 38,
        /// <summary>
        /// 文体娱乐-娱乐休闲
        /// </summary>
        [Description("文体娱乐-娱乐休闲")]
        文体娱乐_娱乐休闲 = 39,
        /// <summary>
        /// 印刷-印刷
        /// </summary>
        [Description("印刷-印刷")]
        印刷_印刷 = 40,
        /// <summary>
        /// 其它-其它
        /// </summary>
        [Description("其它-其它")]
        其它_其它 = 41,
    }
}