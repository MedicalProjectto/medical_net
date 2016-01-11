using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(F8YL.Startup))]
namespace F8YL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
