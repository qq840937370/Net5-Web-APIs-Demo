# Net5-Web-APIs-Demo-NET5
Socket(TCP,UDP)、Webservice、WCF、WebAPI示例-NET5
##NET5
###ASP.NETCoreWebAPI:WebAPI工程

####1.启动界面：
	a.设置默认启动时调用的方法：设置-启动方式-api/ValuesTest/Get
	b.使用swagger可视化API框架时的方法：启动项设置为swagger

####2.路由规则：
    /// <summary>
    /// 第一个案例
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesTestController : ControllerBase
    {。。。}
上段代码的[Route("api/[controller]/[action]")]，指名访问规则是api/控制器名/方法名，还可以写成下面的格式。
	`[Route("api/[controller]/[action]")]`https://localhost:44344/api/ValuesTest/Get
	`[Route("[controller]/[action]")]`https://localhost:44344/ValuesTest/Get
	`[Route("[controller]")]`https://localhost:44344/ValuesTest