namespace WebApplicationWithInterfaceSegregation
{
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using System.Web.Http;
    using WebApplicationWithInterfaceSegregation.Services;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            var registration = Lifestyle.Scoped.CreateRegistration<Service>(container);
            container.AddRegistration(typeof(IReader), registration);
            container.AddRegistration(typeof(IWriter), registration);
            // The following will also work
            //container.Register<IReader, Service>(Lifestyle.Scoped);
            //container.Register<IWriter, Service>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            // Here your usual Web API configuration stuff.
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
