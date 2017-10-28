using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LifeBook.App.Startup))]

namespace LifeBook.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
