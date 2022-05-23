using HR.EmployeeManagement.Application.Contracts.Persistance;
using HR.EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.EmployeeManagement.Persistance.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

        }
    }
}
