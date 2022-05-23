using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeBasicVM>>
    {
        public bool IncludeTeamData { get; set; }
    }
}
