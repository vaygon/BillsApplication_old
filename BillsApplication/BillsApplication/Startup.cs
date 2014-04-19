using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BillsApplication.Startup))]
namespace BillsApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
