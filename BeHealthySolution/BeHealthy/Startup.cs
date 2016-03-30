using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeHealthy.Startup))]
namespace BeHealthy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
