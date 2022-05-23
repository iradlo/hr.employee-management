using HR.EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Contracts.Persistance
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<List<Employee>> GetEmployeesWithTeamData();
    }
}
