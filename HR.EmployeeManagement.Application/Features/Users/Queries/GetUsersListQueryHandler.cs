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
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UsersVM>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepo;

        public GetUsersListQueryHandler(IMapper mapper, IAsyncRepository<User> userRepo)
        {
            this._mapper = mapper;
            this._userRepo = userRepo;
        }

        public async Task<List<UsersVM>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepo.GetAllAsync();

            return _mapper.Map<List<UsersVM>>(users);
        }
    }
}
