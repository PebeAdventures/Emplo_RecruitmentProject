using Emplo_RecruitmentProject.Core.Models;

namespace Emplo_RecruitmentProject.Core.DTOs;
public class EmployeeVacationContext
{
    public required Employee Employee { get; init; }
    public required VacationPackage VacationPackage { get; init; }
    public List<Vacation> Vacations { get; init; } = [];
}
