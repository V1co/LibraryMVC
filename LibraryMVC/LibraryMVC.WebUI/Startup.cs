using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryMVC.WebUI.Startup))]
namespace LibraryMVC.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
