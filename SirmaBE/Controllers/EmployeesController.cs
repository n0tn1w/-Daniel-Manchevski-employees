using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirmaBE.DB;
using SirmaBE.Models.Database;
using SirmaBE.Models.Respone;
using SirmaBE.Services;

namespace SirmaBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        { 
            return Ok(await this._employeeService.GetAll());
        }

        [Route("Pair")]
        [HttpGet]
        public async Task<IActionResult> getBestPair()
        {
            return Ok(await this._employeeService.GetBestPair());
        }

        [Route("Upload")]
        [HttpPost]
        public async Task<IActionResult> postUploadFile([FromForm] IFormFile file) 
        {
            await this._employeeService.UploadFile(file);
            return Ok();
        }
    }
}
