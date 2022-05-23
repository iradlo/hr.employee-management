using System.Collections.Generic;

namespace HR.EmployeeManagement.Application.Features.Teams
{
    public class TeamDetailsVM
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public List<EmployeesDTO> TeamMembers { get; set; }
    }
}
