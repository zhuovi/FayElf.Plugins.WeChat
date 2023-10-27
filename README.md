# FayElf.Plugins.WeChat

![fayelf](https://user-images.githubusercontent.com/16105174/197918392-29d40971-a8a2-4be4-ac17-323f1d0bed82.png)

![GitHub top language](https://img.shields.io/github/languages/top/zhuovi/FayElf.Plugins.WeChat?logo=github)
![GitHub License](https://img.shields.io/github/license/zhuovi/FayElf.Plugins.WeChat?logo=github)
![Nuget Downloads](https://img.shields.io/nuget/dt/FayElf.Plugins.WeChat?logo=nuget)
![Nuget](https://img.shields.io/nuget/v/FayElf.Plugins.WeChat?logo=nuget)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/FayElf.Plugins.WeChat?label=dev%20nuget&logo=nuget)

Nuget：XiaoFeng

| QQ群号 | QQ群 | 公众号 |
| :----:| :----: | :----: |
| 748408911  | ![QQ 群](https://user-images.githubusercontent.com/16105174/198058269-0ea5928c-a2fc-4049-86da-cca2249229ae.png) | ![畅聊了个科技](https://user-images.githubusercontent.com/16105174/198059698-adbf29c3-60c2-4c76-b894-21793b40cf34.jpg) |


源码： https://github.com/zhuovi/FayElf.Plugins.WeChat

教程： https://www.yuque.com/fayelf/xiaofeng

包含了微信公众号，小程序接口


## FayElf.Plugins.WeChat

XiaoFeng generator with [XiaoFeng](https://github.com/zhuovi/FayElf.Plugins.WeChat).

## Install

.NET CLI

```
$ dotnet add package FayElf.Plugins.WeChat --version 1.0.4
```

Package Manager

```
PM> Install-Package FayElf.Plugins.WeChat -Version 1.0.4
```

PackageReference

```
<PackageReference Include="FayElf.Plugins.WeChat" Version="1.0.4" />
```

Paket CLI

```
> paket add FayElf.Plugins.WeChat --version 1.0.4
```

Script & Interactive

```
> #r "nuget: FayElf.Plugins.WeChat, 1.0.4"
```

Cake

```
// Install XiaoFeng as a Cake Addin
#addin nuget:?package=FayElf.Plugins.WeChat&version=1.0.4

// Install XiaoFeng as a Cake Tool
#tool nuget:?package=FayElf.Plugins.WeChat&version=1.0.4
```

# XiaoFeng 类库包含库
| 命名空间 | 所属类库 | 开源状态 | 说明 | 包含功能 |
| :----| :---- | :---- | :----: | :---- |
| XiaoFeng.Prototype | XiaoFeng.Core | :white_check_mark: | 扩展库 | ToCase 类型转换<br/>ToTimestamp,ToTimestamps 时间转时间戳<br/>GetBasePath 获取文件绝对路径,支持Linux,Windows<br/>GetFileName 获取文件名称<br/>GetMatch,GetMatches,GetMatchs,IsMatch,ReplacePatten,RemovePattern 正则表达式操作<br/> |
| XiaoFeng.Net | XiaoFeng.Net | :white_check_mark: | 网络库 | XiaoFeng网络库，封装了Socket客户端，服务端（Socket,WebSocket），根据当前库可轻松实现订阅，发布等功能。|
| XiaoFeng.Http | XiaoFeng.Core | :white_check_mark: | 模拟请求库 | 模拟网络请求 |
| XiaoFeng.Data | XiaoFeng.Core | :white_check_mark: | 数据库操作库 | 支持SQLSERVER,MYSQL,ORACLE,达梦,SQLITE,ACCESS,OLEDB,ODBC等数十种数据库 |
| XiaoFeng.Cache | XiaoFeng.Core | :white_check_mark: | 缓存库 |  内存缓存,Redis,MemcachedCache,MemoryCache,FileCache缓存 |
| XiaoFeng.Config | XiaoFeng.Core | :white_check_mark: | 配置文件库 | 通过创建模型自动生成配置文件，可为xml,json,ini文件格式 |
| XiaoFeng.Cryptography | XiaoFeng.Core | :white_check_mark: | 加密算法库 | AES,DES,RSA,MD5,DES3,SHA,HMAC,RC4加密算法 |
| XiaoFeng.Excel | XiaoFeng.Excel | :white_check_mark: | Excel操作库 | Excel操作，创建excel,编辑excel,读取excel内容，边框，字体，样式等功能  |
| XiaoFeng.Ftp | XiaoFeng.Ftp | :white_check_mark: | FTP请求库 | FTP客户端 |
| XiaoFeng.IO | XiaoFeng.Core | :white_check_mark: | 文件操作库 | 文件读写操作 |
| XiaoFeng.Json | XiaoFeng.Core | :white_check_mark: | Json序列化，反序列化库 | Json序列化，反序列化库 |
| XiaoFeng.Xml | XiaoFeng.Core | :white_check_mark: | Xml序列化，反序列化库 | Xml序列化，反序列化库 |
| XiaoFeng.Log | XiaoFeng.Core | :white_check_mark: | 日志库 | 写日志文件,数据库 |
| XiaoFeng.Memcached | XiaoFeng.Memcached | :white_check_mark: | Memcached缓存库 | Memcached中间件,支持.NET框架、.NET内核和.NET标准库,一种非常方便操作的客户端工具。实现了Set,Add,Replace,PrePend,Append,Cas,Get,Gets,Gat,Gats,Delete,Touch,Stats,Stats Items,Stats Slabs,Stats Sizes,Flush_All,Increment,Decrement,线程池功能。|
| XiaoFeng.Redis | XiaoFeng.Redis | :white_check_mark: | Redis缓存库 | Redis中间件,支持.NET框架、.NET内核和.NET标准库,一种非常方便操作的客户端工具。实现了Hash,Key,String,ZSet,Stream,Log,List,订阅发布,线程池功能; |
| XiaoFeng.Threading | XiaoFeng.Core | :white_check_mark: | 线程库 | 线程任务,线程队列 |
| XiaoFeng.Mvc | XiaoFeng.Mvc | :x: | 低代码WEB开发框架 | .net core 基础类，快速开发CMS框架，真正的低代码平台，自带角色权限，WebAPI平台，后台管理，可托管到服务运行命令为:应用.exe install 服务名 服务说明,命令还有 delete 删除 start 启动  stop 停止。 |
| XiaoFeng.Proxy | XiaoFeng.Proxy | :white_check_mark: | 代理库 | 开发中 |
| XiaoFeng.TDengine | XiaoFeng.TDengine | :white_check_mark: | TDengine 客户端 | 开发中 |
| XiaoFeng.GB28181 | XiaoFeng.GB28181 | :white_check_mark: | 视频监控库，SIP类库，GB28181协议 | 开发中 |
| XiaoFeng.Onvif | XiaoFeng.Onvif | :white_check_mark: | 视频监控库Onvif协议 | XiaoFeng.Onvif 基于.NET平台使用C#封装Onvif常用接口、设备、媒体、云台等功能， 拒绝WCF服务引用动态代理生成wsdl类文件 ， 使用原生XML扩展标记语言封装参数，所有的数据流向都可控。 |
| FayElf.Plugins.WeChat | FayElf.Plugins.WeChat | :white_check_mark: | 微信公众号，小程序类库 | 微信公众号，小程序类库。 |

### FayElf.Plugins.WeChat 用法实例

#### 微信公众号

```csharp
var receive = new FayElf.Plugins.WeChat.OfficialAccount.Receive();
var msg = receive.RequestMessage(this.Request, (message, xValue) =>
{
    //message 是收到的结构消息
    //xvalue 是xml结构数据
    if (message.IsNullOrEmpty()) return "error";
    if (message.Event == FayElf.Plugins.WeChat.EventType.subscribe)
    {
        //订阅事件
    }
    else if (message.Event == FayElf.Plugins.WeChat.EventType.unsubscribe)
    {
        //取消订阅事件
    }
    if (message.MsgType == Plugins.WeChat.MessageType.text)
    {
        //接收回复消息
    }
    return string.Empty;
});
if (this.Request.Method == HttpMethod.Get.ToString())
{
    if (msg == "error") return Content("error");
    else return Content(msg);
}
return Content(msg);
```

#### 微信小程序

```csharp

```

#### JsSDK

```csharp
var sign = new FayElf.Plugins.WeChat.JSSDK().GetSignature(XiaoFeng.Mvc.Web.HttpContext.Current.Request.GetUri().ToString());
//sign模型
/// <summary>
    /// 签名模型
    /// </summary>
    public class SignatureModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public SignatureModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// Noice字符串
        /// </summary>
        public string NonceString { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public int Timestamp { get; set; }
        /// <summary>
        /// 原始字符串
        /// </summary>
        public string RawString { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }
        #endregion

        #region 方法

        #endregion
    }
```



# 作者介绍



* 网址 : http://www.fayelf.com
* QQ : 7092734
* EMail : jacky@fayelf.com

