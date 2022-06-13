using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Users
{
    public class LoginInfo
    {
        public LoginInfo(string msg)
        {
            Message = msg;
        }

        public string Message { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
