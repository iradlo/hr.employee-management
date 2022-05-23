using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAsyncRepository<Team> _teamRepository;

        public CreateEmployeeCommandHandler(IMapper mapper, 
                IAsyncRepository<Employee> employeeRepository,
                IAsyncRepository<Team> teamRepository)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
            this._teamRepository = teamRepository;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.Team.TeamId);

            var employee = _mapper.Map<Employee>(request);
            employee.TeamData = team;

            employee = await _employeeRepository.AddNewAsync(employee);

            return employee.EmployeeId;
        }
    }
}
