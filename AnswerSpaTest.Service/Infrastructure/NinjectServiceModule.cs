namespace AnswerSpaTest.Service.Infrastructure
{
	using Ninject.Modules;
	using Services;

	public class NinjectServiceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<PersonService>().ToSelf();
			Bind<ColourService>().ToSelf();
		}
	}
}
