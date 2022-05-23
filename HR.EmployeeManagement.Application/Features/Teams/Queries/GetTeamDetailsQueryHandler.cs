using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class GetTeamDetailsQueryHandler : IRequestHandler<GetTeamDetailsQuery, TeamDetailsVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Team> _teamRepo;
        private readonly IAsyncRepository<Employee> _employeeRepo;

        public GetTeamDetailsQueryHandler(IMapper mapper, 
            IAsyncRepository<Team> teamRepo, 
            IAsyncRepository<Employee> employeeRepo)
        {
            this._mapper = mapper;
            this._teamRepo = teamRepo;
            this._employeeRepo = employeeRepo;
        }

        public async Task<TeamDetailsVM> Handle(GetTeamDetailsQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepo.GetByIdAsync(request.Id);
            if(team == null)
            {
                throw new ApplicationException("Team is not found"); 
            }

            IReadOnlyList<Employee> employees = await _employeeRepo.GetAllAsync();
            var teamMembers = employees.Where(employee => employee.TeamId == request.Id)
                                       .Select(employee => _mapper.Map<EmployeesDTO>(employee)).ToList();

            var teamDetails = _mapper.Map<TeamDetailsVM>(team);
            teamDetails.TeamMembers = teamMembers;

            return teamDetails;
        }
    }
}
