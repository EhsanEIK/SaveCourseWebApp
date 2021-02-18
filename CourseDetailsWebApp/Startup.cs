using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseDetailsWebApp.Startup))]
namespace CourseDetailsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
