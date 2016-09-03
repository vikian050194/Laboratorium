using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laboratorium.Startup))]
namespace Laboratorium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
