using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepo;

        public DeleteUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepo)
        {
            this._mapper = mapper;
            this._userRepo = userRepo;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _userRepo.GetByIdAsync(request.Id);
            if(toDelete == null)
            {
                throw new ApplicationException("User is not found");
            }

            await _userRepo.DeleteAsync(toDelete);

            return Unit.Value;
        }
    }
}
