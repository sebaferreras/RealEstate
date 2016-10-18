using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_01.RealEstate.API.Startup))]

namespace _01.RealEstate.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
