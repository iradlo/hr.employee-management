using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Employee> _employeeRepo;

        public DeleteEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepo)
        {
            this._mapper = mapper;
            this._employeeRepo = employeeRepo;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeRepo.GetByIdAsync(request.EmployeeId);

            if(employeeToDelete == null)
            {
                throw new ApplicationException("Employee is not found");
            }

            await _employeeRepo.DeleteAsync(employeeToDelete);

            return Unit.Value;
        }
    }
}
