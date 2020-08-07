using Common.WebStore.DomainNew.ApiModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Services.WebStore.Interfaces
{
    public interface IStudentsService
    {
        IEnumerable<StudentModel> Get();

        Task<IEnumerable<StudentModel>> GetAsync();

        StudentModel Get(int id);
        Task<StudentModel> GetAsync(int id);

        Uri Post(StudentModel value);

        Task<Uri> PostAsync(StudentModel value);

        HttpStatusCode Put(int id, StudentModel value);

        Task<HttpStatusCode> PutAsync(int id, StudentModel value);

        HttpStatusCode Delete(int id);

        Task<HttpStatusCode> DeleteAsync(int id);
    }
}

