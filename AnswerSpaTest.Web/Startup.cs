using AnswerSpaTest.Web;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace AnswerSpaTest.Web
{
	using System.Reflection;
	using System.Web.Http;
	using Data.Infrastructure;
	using Service.Infrastructure;
	using Ninject;
	using Ninject.Web.Common.OwinHost;
	using Ninject.Web.WebApi.OwinHost;
	using Owin;

	public class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			var config = new HttpConfiguration();
			WebApiConfig.Register(config);

			appBuilder.UseNinjectMiddleware(CreateKernel);
			appBuilder.UseNinjectWebApi(config);
		}

		public static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());

			kernel.Load(new NinjectServiceModule());
			kernel.Load(new NinjectDataModule());

			return kernel;
		}
	}
}