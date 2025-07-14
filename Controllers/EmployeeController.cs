using Microsoft.AspNetCore.Mvc;

namespace proj1.Controllers
{
    public class EmployeeController : Controller
    {
        string name= "mohammad";
       public ViewResult Index()
        {
            return View("Index",name);
        }
        public ViewResult Create()
        {
            return View();
        }
    }
}
