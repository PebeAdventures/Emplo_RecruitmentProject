using Emplo_RecruitmentProject.Core.Models;

namespace Emplo_RecruitmentProject.Core.DTOs;

public class EmployeeStructure
{
    public int EmployeeId { get; set; }
    public int SuperiorId { get; set; }
    public int Level { get; set; } 
}
