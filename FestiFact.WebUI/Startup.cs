using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FestiFact.WebUI.Startup))]
namespace FestiFact.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
