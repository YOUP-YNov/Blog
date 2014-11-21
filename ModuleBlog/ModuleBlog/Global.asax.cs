using ModuleBlog.App_Start;
using System.Web.Http;
using System.Web.Mvc;

namespace ModuleBlog
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();

            AutoMapperConfiguration.CreateMap();
            ModuleBlog.BLL.AutoMapperConfiguration.CreateMap();
        }

        
    }
}
