using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDoctor.Startup))]
namespace WebDoctor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
