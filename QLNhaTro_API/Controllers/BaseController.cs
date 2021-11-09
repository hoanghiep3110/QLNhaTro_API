using System.Web.Mvc;

namespace QLNhaTro_API.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Session["UserAdmin"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~");
            }
        }
    }
}