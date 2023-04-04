using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng;
using FayElf.Plugins.WeChat.OfficialAccount.Model;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-16 10:55:30                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount
{
    /// <summary>
    /// 自定义菜单操作类
    /// </summary>
    public class Menu
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public Menu()
        {
            this.Config = Config.Current;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 配置
        /// </summary>
        public Config Config { get; set; }
        #endregion

        #region 方法

        #region  创建菜单
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="buttons">菜单列表</param>
        /// <returns></returns>
        public BaseResult CreateMenu(List<ButtonModel> buttons)
        {
            if (buttons == null || buttons.Count == 0)
                return new BaseResult
                {
                    ErrCode = 500,
                    ErrMsg = "数据不能为空."
                };
            var config = this.Config.GetConfig(WeChatType.OfficeAccount);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = XiaoFeng.Http.HttpHelper.GetHtml(new XiaoFeng.Http.HttpRequest
                {
                    Method = "POST",
                    Address = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + token.AccessToken,
                    BodyData = buttons.ToJson()
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<BaseResult>();
                }
                else
                {
                    return new BaseResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 删除菜单
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        public BaseResult DeleteMenu()
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = XiaoFeng.Http.HttpHelper.GetHtml(new XiaoFeng.Http.HttpRequest
                {
                    Method = "GET",
                    Address = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + token.AccessToken
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<BaseResult>();
                }
                else
                {
                    return new BaseResult
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #region 获取自定义菜单
        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <returns></returns>
        public MenuModel GetMenu()
        {
            var config = this.Config.GetConfig(WeChatType.Applets);
            return Common.Execute(config.AppID, config.AppSecret, token =>
            {
                var response = XiaoFeng.Http.HttpHelper.GetHtml(new XiaoFeng.Http.HttpRequest
                {
                    Method = "GET",
                    Address = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + token.AccessToken
                });
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return response.Html.JsonToObject<MenuModel>();
                }
                else
                {
                    return new MenuModel
                    {
                        ErrCode = 500,
                        ErrMsg = "请求失败."
                    };
                }
            });
        }
        #endregion

        #endregion
    }
}