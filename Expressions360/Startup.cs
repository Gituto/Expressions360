using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Expressions360.Startup))]
namespace Expressions360
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
