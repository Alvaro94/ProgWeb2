using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TareasCRUD.Startup))]
namespace TareasCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
