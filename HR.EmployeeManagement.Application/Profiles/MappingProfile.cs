using AutoMapper;
using HR.EmployeeManagement.Application.Features.Employees;
using HR.EmployeeManagement.Application.Features.Teams;
using HR.EmployeeManagement.Application.Features.Users;
using HR.EmployeeManagement.Domain.Entities;

namespace HR.EmployeeManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Employee, EmployeeDetailVM>().ReverseMap();
            CreateMap<Employee, EmployeeBasicVM>().ReverseMap();

            CreateMap<Employee, EmployeesDTO>().ReverseMap();

            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<Team, TeamVM>().ReverseMap();
            CreateMap<Team, TeamDetailsVM>().ReverseMap();
            CreateMap<Team, CreateNewTeamCommand>().ReverseMap();
            CreateMap<Team, UpdateTeamCommand>().ReverseMap();

            CreateMap<User, UsersVM>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
        }
    }
}
