using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloudSchool.Startup))]
namespace CloudSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
