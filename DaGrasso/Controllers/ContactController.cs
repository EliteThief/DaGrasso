using Microsoft.AspNetCore.Mvc;

namespace DaGrasso.Controllers
{
    public class ContactController : Microsoft.AspNetCore.Mvc.Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
