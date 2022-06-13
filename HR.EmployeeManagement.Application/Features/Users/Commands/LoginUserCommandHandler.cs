using AutoMapper;
using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Application.Features.Users
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginInfo>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepo;

        public LoginUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepo)
        {
            this._mapper = mapper;
            this._userRepo = userRepo;
        }

        public async Task<LoginInfo> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepo.GetAllAsync();

                var foundedUser = users.Where(u => u.UserName.Equals(request.Username) && u.Password.Equals(request.Password)).FirstOrDefault();
                if (foundedUser == null)
                {
                    return new LoginInfo("failed");
                }
                
                return GetLoginInfo(foundedUser);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private LoginInfo GetLoginInfo(User foundedUser)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, foundedUser.UserName),
                    new Claim(ClaimTypes.Role, foundedUser.Role)
                };

            var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44307",
                    audience: "https://localhost:44307",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new LoginInfo("successfull") { Username = foundedUser.UserName, Role = foundedUser.Role, Token = tokenString };
        }
    }
}
