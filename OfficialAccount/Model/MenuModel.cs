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
*  Create Time : 2022-03-16 14:15:32                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount.Model
{
    /// <summary>
    /// MenuModel 类说明
    /// </summary>
    public class MenuModel : BaseResult
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public MenuModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 菜单对象
        /// </summary>
        [JsonElement("menu")]
        public Button Menu { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 按扭对象
    /// </summary>
    public class Button
    {
        /// <summary>
        /// 按扭列表
        /// </summary>
        public List<ButtonModel> button { get; set; }
    }
}