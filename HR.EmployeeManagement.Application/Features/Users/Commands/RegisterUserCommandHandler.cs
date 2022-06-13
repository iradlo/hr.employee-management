using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepo;

        public RegisterUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepo)
        {
            this._mapper = mapper;
            this._userRepo = userRepo;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user = await _userRepo.AddNewAsync(user);

            return user.Id;
        }
    }
}
