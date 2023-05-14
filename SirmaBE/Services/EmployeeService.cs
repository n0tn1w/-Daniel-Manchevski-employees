using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirmaBE.DB;
using SirmaBE.Models.Database;
using SirmaBE.Models.Respone;

namespace SirmaBE.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ConectionDbContext _conectionDbContext;

        public EmployeeService(ConectionDbContext conectionDbContext) {
            _conectionDbContext = conectionDbContext;
        }

        public async Task<List<EmployeeProjectModel>> GetAll()
        {
            return await _conectionDbContext.EmployeesProjects.ToListAsync();
        }

        public async Task<BestPair?> GetBestPair()
        {
            BestPair best = new BestPair();
            best.WorkedTogtherInDays = -1;

            var uniqProjectsIds =
                await _conectionDbContext.EmployeesProjects
                .Select(x => x.ProjectID)
                .Distinct()
                .ToListAsync();

            uniqProjectsIds.ForEach(id =>
            {
                List<EmployeeProjectModel> empsForId = _conectionDbContext.EmployeesProjects.Where(x => x.ProjectID == id).ToList();


                foreach (var emp1 in empsForId)
                {
                    foreach (var emp2 in empsForId)
                    {
                        DateTime firstDate = emp1.DateFrom > emp2.DateFrom ? emp1.DateFrom : emp2.DateFrom;
                        DateTime secondDate = emp1.DateTo < emp2.DateTo ? emp1.DateTo : emp2.DateTo;

                        if (firstDate < secondDate && emp1.EmpID != emp2.EmpID)
                        {
                            TimeSpan difference = secondDate - firstDate;
                            double days = difference.TotalDays;

                            if (days > best.WorkedTogtherInDays)
                            {
                                best.EmpID1 = emp1.EmpID;
                                best.EmpID2 = emp2.EmpID;
                                best.ProjectID = id;
                                best.WorkedTogtherInDays = days;
                            }
                        }


                    }
                }

            });
            Console.WriteLine();
            return best.WorkedTogtherInDays != -1 ? best : null;
        }

        public async Task UploadFile(IFormFile file)
        {
            await _conectionDbContext.EmployeesProjects.ExecuteDeleteAsync();

            DateTime today = DateTime.Today;

            List<EmployeeProjectModel> emps = new List<EmployeeProjectModel>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    string[] items = reader.ReadLine().ToString().Split(",");
                    EmployeeProjectModel employeeProjectModel = new EmployeeProjectModel();

                    employeeProjectModel.Id = Guid.NewGuid();
                    employeeProjectModel.EmpID = Int32.Parse(items[0]);
                    employeeProjectModel.ProjectID = Int32.Parse(items[1]);
                    employeeProjectModel.DateFrom = DateTime.Parse(items[2]).Date;
                    if (items[3] == "NULL")
                    {
                        employeeProjectModel.DateTo = today;
                    }
                    else
                    {
                        employeeProjectModel.DateTo = DateTime.Parse(items[3]).Date;
                    }

                    emps.Add(employeeProjectModel);
                }
            }

            await _conectionDbContext.EmployeesProjects.AddRangeAsync(emps);
            await _conectionDbContext.SaveChangesAsync();
        }
    }
}
