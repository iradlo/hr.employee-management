using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Team> _teamRepo;

        public DeleteTeamCommandHandler(IMapper mapper, IAsyncRepository<Team> teamRepo)
        {
            this._mapper = mapper;
            this._teamRepo = teamRepo;
        }

        public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _teamRepo.GetByIdAsync(request.TeamId);

            if (toDelete == null)
            {
                throw new ApplicationException("Team is not found");
            }

            await _teamRepo.DeleteAsync(toDelete);

            return Unit.Value;
        }
    }
}
