using Emplo_RecruitmentProject.Core.DTOs;

namespace Emplo_RecruitmentProject.Core.Services;
public class VacationService
{
    /// <summary>
    /// Calculates how many vacation days are still available for the employee in the current year.
    /// </summary>
    public int CountFreeDaysForEmployee(EmployeeVacationContext context)
    {
        var today = DateTime.Today;

        var usedDays = context.Vacations
            .Where(v => !v.IsPartialVacation && v.DateUntil < today)
            .Sum(v => (int)(v.DateUntil - v.DateSince).TotalDays);

        var granted = context.VacationPackage.GrantedDays;

        var remaining = granted - usedDays;
        return remaining >= 0 ? remaining : 0;
    }
}
