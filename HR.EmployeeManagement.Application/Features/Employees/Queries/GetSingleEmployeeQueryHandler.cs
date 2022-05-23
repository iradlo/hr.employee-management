using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class GetSingleEmployeeQueryHandler : IRequestHandler<GetSingleEmployeeQuery, EmployeeDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAsyncRepository<Team> _teamDataRepository;

        public GetSingleEmployeeQueryHandler(IMapper mapper,
            IAsyncRepository<Employee> employeeRepository,
            IAsyncRepository<Team> teamDataRepository)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
            this._teamDataRepository = teamDataRepository;
        }

        public async Task<EmployeeDetailVM> Handle(GetSingleEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                throw new ApplicationException("Employee is not found");
            }

            var employeeDetail = _mapper.Map<EmployeeDetailVM>(employee);

            var teamData = await _teamDataRepository.GetByIdAsync(employee.TeamId);
            if (teamData == null)
            {
                throw new ApplicationException("Employee team data is not found");
            }
            employeeDetail.Team = _mapper.Map<TeamDTO>(teamData);

            return employeeDetail;
        }
    }
}
