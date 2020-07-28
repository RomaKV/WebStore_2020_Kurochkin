using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI.WebStore.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.WebStore.Controllers
{
    [SimpleActionFilter]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly IValuesService valuesService;
        private readonly IStudentsService studentService;

        public  HomeController(IValuesService valuesService, IStudentsService studentService)
        {
            this.valuesService = valuesService;
            this.studentService = studentService;
        }
        
        public async Task<IActionResult> IndexAsync()
        {
           var values = await this.studentService.GetAsync();
           
            return View(values);
        }

        //public IActionResult Index()
        //{
        //    //throw new ApplicationException("Ошибочка вышла...");
        //    return View();
        //}

        // GET: /<controller>/blog
        [SimpleActionFilter]
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
