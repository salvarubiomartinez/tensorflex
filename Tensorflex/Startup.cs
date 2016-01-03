using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tensorflex.Startup))]
namespace Tensorflex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
