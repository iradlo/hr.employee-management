using MediatR;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class DeleteTeamCommand : IRequest
    {
        public int TeamId { get; set; }
    }
}
