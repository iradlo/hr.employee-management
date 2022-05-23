using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Team> _teamRepo;

        public UpdateTeamCommandHandler(IMapper mapper, IAsyncRepository<Team> teamRepo)
        {
            this._mapper = mapper;
            this._teamRepo = teamRepo;
        }

        public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var teamToUpdate = await _teamRepo.GetByIdAsync(request.TeamId);
            if (teamToUpdate == null)
            {
                throw new ApplicationException("Team is not found");
            }

            _mapper.Map(request, teamToUpdate, typeof(UpdateTeamCommand), typeof(Employee));
            await _teamRepo.UpdateAsync(teamToUpdate);

            return Unit.Value;
        }
    }
}
