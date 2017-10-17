using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lifebook.Web.Startup))]
namespace Lifebook.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
