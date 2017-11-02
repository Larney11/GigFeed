using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigFeed.Startup))]
namespace GigFeed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
