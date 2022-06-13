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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepo;

        public UpdateUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepo)
        {
            this._mapper = mapper;
            this._userRepo = userRepo;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepo.GetByIdAsync(request.UserId);
            if(userToUpdate == null)
            {
                throw new ApplicationException("No user found");
            }

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));
            await _userRepo.UpdateAsync(userToUpdate);

            return Unit.Value;
        }
    }
}
