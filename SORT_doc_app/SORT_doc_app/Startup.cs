using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SORT_doc_app.Startup))]
namespace SORT_doc_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
