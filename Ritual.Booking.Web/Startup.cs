using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ritual.Booking.Web.Startup))]
namespace Ritual.Booking.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
