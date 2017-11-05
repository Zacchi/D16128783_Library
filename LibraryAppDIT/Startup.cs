using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryAppDIT.Startup))]
namespace LibraryAppDIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
