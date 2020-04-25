using System.Web.Mvc;

namespace MVC_Northwind.Areas.Kullanıcı
{
    public class KullanıcıAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Kullanıcı";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Kullanıcı_default",
                "Kullanıcı/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}