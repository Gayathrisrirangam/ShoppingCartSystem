using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingSystemMVC.Startup))]
namespace ShoppingSystemMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
