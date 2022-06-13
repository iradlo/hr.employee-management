using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Users
{
    public class GetUsersListQuery : IRequest<List<UsersVM>>
    {
    }
}