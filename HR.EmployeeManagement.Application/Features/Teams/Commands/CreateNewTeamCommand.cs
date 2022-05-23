using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class CreateNewTeamCommand : IRequest<int>
    {
        public string TeamName { get; set; }
        public string Description { get; set; }
    }
}
