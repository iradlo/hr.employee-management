using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Users
{
    public class LoginUserCommand : IRequest<LoginInfo>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
