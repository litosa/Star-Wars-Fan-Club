using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SWFC.Startup))]
namespace SWFC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
