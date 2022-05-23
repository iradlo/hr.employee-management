using MediatR;

namespace HR.EmployeeManagement.Application.Features.Employees
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
    }
}
