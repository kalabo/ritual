using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ritual.Web.Members.Startup))]
namespace Ritual.Web.Members
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
