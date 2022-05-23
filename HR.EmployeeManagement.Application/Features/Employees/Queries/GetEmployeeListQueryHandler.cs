using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeBasicVM>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeListQueryHandler(IMapper mapper, 
            IEmployeeRepository employeeRepository)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeBasicVM>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Employee> allEmployees; 
            if (request.IncludeTeamData)
            {
                allEmployees = await _employeeRepository.GetEmployeesWithTeamData();
            }
            else
            {
                allEmployees = await _employeeRepository.GetAllAsync();
            }

            var retData = _mapper.Map<List<EmployeeBasicVM>>(allEmployees);

            return retData;
        }
    }
}
