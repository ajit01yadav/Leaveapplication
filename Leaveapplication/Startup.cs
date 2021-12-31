using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Leaveapplication.Startup))]
namespace Leaveapplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
