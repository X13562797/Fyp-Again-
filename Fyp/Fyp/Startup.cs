using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fyp.Startup))]
namespace Fyp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
