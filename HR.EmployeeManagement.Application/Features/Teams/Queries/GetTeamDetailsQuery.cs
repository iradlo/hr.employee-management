using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class GetTeamDetailsQuery : IRequest<TeamDetailsVM>
    {
        public int Id { get; set; }
    }
}
