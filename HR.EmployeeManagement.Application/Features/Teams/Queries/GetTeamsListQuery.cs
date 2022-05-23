using MediatR;
using System.Collections.Generic;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class GetTeamsListQuery : IRequest<List<TeamVM>>
    {
    }
}
