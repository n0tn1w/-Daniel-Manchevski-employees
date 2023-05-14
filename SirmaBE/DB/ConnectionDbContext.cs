using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirmaBE.Models.Database;
using System.Collections.Generic;

namespace SirmaBE.DB
{
    public class ConectionDbContext : DbContext
    {

        public ConectionDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EmployeeProjectModel> EmployeesProjects { get; set; }
    }
}
