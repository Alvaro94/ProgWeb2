using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tarea.Startup))]
namespace tarea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
