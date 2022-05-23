using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Employee> _employeeRepo;
        private readonly IAsyncRepository<Team> _teamRepo;

        public UpdateEmployeeCommandHandler(IMapper mapper, 
                                            IAsyncRepository<Employee> employeeRepo,
                                            IAsyncRepository<Team> teamRepo)
        {
            this._mapper = mapper;
            this._employeeRepo = employeeRepo;
            this._teamRepo = teamRepo;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.GetByIdAsync(request.EmployeeId);
            if(employee == null)
            {
                throw new ApplicationException("Employee is not found");
            }

            var team = await _teamRepo.GetByIdAsync(request.Team.TeamId);

            _mapper.Map(request, employee, typeof(UpdateEmployeeCommand), typeof(Employee));

            employee.TeamId = team.TeamId;
            employee.TeamData = team;
            await _employeeRepo.UpdateAsync(employee);

            return Unit.Value;
        }
    }
}
