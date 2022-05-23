using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HR.EmployeeManagement.Persistance.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Employee>> GetEmployeesWithTeamData()
        {
            var allData = await _dbContext.Employees.Include(x => x.TeamData).ToListAsync();
            return allData;
        }
    }
}
