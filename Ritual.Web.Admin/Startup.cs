using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ritual.Web.Admin.Startup))]
namespace Ritual.Web.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
