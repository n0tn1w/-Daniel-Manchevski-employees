using Microsoft.AspNetCore.Mvc;
using SirmaBE.Models.Database;
using SirmaBE.Models.Respone;

namespace SirmaBE.Services
{
    public interface IEmployeeService
    {
        Task<BestPair?> GetBestPair();

        Task UploadFile(IFormFile file);

        Task<List<EmployeeProjectModel>> GetAll();
    }
}
