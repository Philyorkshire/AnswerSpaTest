namespace AnswerSpaTest.Data.Infrastructure
{
	using Ninject.Modules;
	using Ninject.Web.Common;

	public class NinjectDataModule : NinjectModule
	{
		public override void Load()
		{
			Bind<AnswerSpaTestContext>().ToSelf().InRequestScope();
		}
	}
}
