using System;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<HomeController> logger;

        public HomeController(IValuesService valuesService, IStudentsService studentService,
            ILogger<HomeController> logger)
        {
            this.valuesService = valuesService;
            this.studentService = studentService;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           

            logger?.LogTrace("[TRACE] logger!");
            logger?.LogInformation("[INFO] logger!");
            logger?.LogWarning("[WARN] logger!");
            logger?.LogDebug("[DEBUG] logger!");
            logger?.LogError("[ERROR] logger!");
            logger?.LogCritical("[CRITICAL] logger!");

            throw new ApplicationException("Тест сообщений об ошибках");;

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

       
        public IActionResult ErrorStatus(string id)
        {
            if (id == "404")
            {
                return RedirectToAction($"NotFound");
            }

            return Content($"Статусный код ошибки: {id}");
        }
}
}
