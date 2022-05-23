using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class GetSingleEmployeeQuery : IRequest<EmployeeDetailVM>
    {
        public int Id { get; set; }
    }
}
