using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public TeamDTO Team { get; set; }
    }
}
