using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Users
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
