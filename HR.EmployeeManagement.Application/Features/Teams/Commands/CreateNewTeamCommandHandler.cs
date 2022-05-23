using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class CreateNewTeamCommandHandler : IRequestHandler<CreateNewTeamCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Team> _teamRepo;

        public CreateNewTeamCommandHandler(IMapper mapper, IAsyncRepository<Team> teamRepo)
        {
            this._mapper = mapper;
            this._teamRepo = teamRepo;
        }

        public async Task<int> Handle(CreateNewTeamCommand request, CancellationToken cancellationToken)
        {
            var team = _mapper.Map<Team>(request);
            team = await _teamRepo.AddNewAsync(team);

            return team.TeamId;
        }
    }
}
