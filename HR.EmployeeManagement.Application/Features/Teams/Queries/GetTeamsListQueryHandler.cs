using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class GetTeamsListQueryHandler : IRequestHandler<GetTeamsListQuery, List<TeamVM>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Team> _teamRepo;

        public GetTeamsListQueryHandler(IMapper mapper, IAsyncRepository<Team> teamRepo)
        {
            this._mapper = mapper;
            this._teamRepo = teamRepo;
        }

        public async Task<List<TeamVM>> Handle(GetTeamsListQuery request, CancellationToken cancellationToken)
        {
            var allTeams = await _teamRepo.GetAllAsync();
            return _mapper.Map<List<TeamVM>>(allTeams);
        }
    }
}
