using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examen_Alvaro.Startup))]
namespace Examen_Alvaro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
