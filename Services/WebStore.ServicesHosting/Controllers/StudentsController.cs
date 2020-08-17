using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.WebStore.ServicesHosting.Controllers
{
   
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> logger; 
        public StudentsController(ILogger<StudentsController> logger)
        {
            this.logger = logger;
        }

        private IEnumerable<StudentModel> GetStudents()
        {

            logger?.LogTrace("[TRACE] logger!");
            logger?.LogInformation("[INFO] logger!");
            logger?.LogWarning("[WARN] logger!");
            logger?.LogDebug("[DEBUG] logger!");
            logger?.LogError("[ERROR] logger!");
            logger?.LogCritical("[CRITICAL] logger!");



            List<StudentModel> students = new List<StudentModel> {
                new StudentModel
                {
                    Id = 1,
                    Name = "Роман",
                    Surname = "Курочкин"
                },
                new StudentModel
                {
                    Id = 2,
                    Name = "Иван",
                    Surname = "Кузьминых"
                },
                new StudentModel
                {
                    Id = 3,
                    Name = "Владимир",
                    Surname = "Волнухин"
                },
                new StudentModel
                {
                    Id = 4,
                    Name = "Владислав",
                    Surname = "Павленко"
                },
                new StudentModel
                {
                    Id = 5,
                    Name = "Никита",
                    Surname = "Лузгин"
                },
                new StudentModel
                {
                    Id = 6,
                    Name = "Артемий",
                    Surname = "Уваров"
                },
                 new StudentModel
                 {
                     Id = 7,
                     Name = "Павел",
                     Surname = "Савченко"
                 }
             };

            return students;                              
        }

        [HttpGet]
        [Route("students/list")]
        public IEnumerable<StudentModel> Get()
        {
            return GetStudents();
        }

        [HttpGet]
        [Route("students/{id}")]
        public StudentModel Get(int id)
        {
            return GetStudents().SingleOrDefault(x => x.Id.Equals(id));
        }

    }
}
