using FayElf.Plugins.WeChat.OfficialAccount.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using XiaoFeng.Http;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng;
/****************************************************************
*  Copyright © (2022) www.fayelf.com All Rights Reserved.       *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@fayelf.com                                     *
*  Site : www.fayelf.com                                        *
*  Create Time : 2022-03-16 15:18:40                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace FayElf.Plugins.WeChat.OfficialAccount
{
    /// <summary>
    /// 二维码
    /// </summary>
    public class QRCode
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public QRCode()
        {

        }
        #endregion

        #region 属性

        #endregion

        #region 方法
        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="accessToken">网页授权接口调用凭证</param>
        /// <param name="qrcodeType">二维码类型</param>
        /// <param name="scene_id">开发者自行设定的参数</param>
        /// <param name="seconds">该二维码有效时间，以秒为单位。 最大不超过2592000（即30天），此字段如果不填，则默认有效期为60秒。</param>
        /// <returns></returns>
        public static QRCodeResult CreateParameterQRCode(string accessToken, QrcodeType qrcodeType, int scene_id, int seconds = 60)
        {
            var result = HttpHelper.GetHtml(new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={accessToken}",
                BodyData = $@"{{{(qrcodeType == QrcodeType.QR_STR_SCENE ? ($@"""expire_seconds"":{seconds},") : "")}""action_name"": ""{qrcodeType}"", ""action_info"": {{""scene"": {{""scene_id"": {scene_id}}}}}}}"
            });
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.Html.JsonToObject<QRCodeResult>();
            }
            else
                return new QRCodeResult
                {
                    ErrCode = 500,
                    ErrMsg = "请求出错."
                };
        }
        #endregion

        #region 通过ticket 获取二维码
        /// <summary>
        /// 通过ticket 获取二维码
        /// </summary>
        /// <param name="ticket">二维码ticket</param>
        /// <returns>ticket正确情况下，http 返回码是200，是一张图片，可以直接展示或者下载。</returns>
        public static byte[] GetQrCode(string ticket)
        {
            return HttpHelper.GetHtml($"https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={ticket}").Data;
        }
        #endregion
    }
}