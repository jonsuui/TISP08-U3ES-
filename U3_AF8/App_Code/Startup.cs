using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(U3_AF8.Startup))]
namespace U3_AF8
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
