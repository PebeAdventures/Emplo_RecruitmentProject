using Emplo_RecruitmentProject.Core.DTOs;
using Emplo_RecruitmentProject.Core.Models;

namespace Emplo_RecruitmentProject.Tests.TestData;
public static class MockData
{
    // ---- Vacation builders ----

    /// <summary>
    /// Builds a full vacation that ended yesterday and lasted exactly 'days' days.
    /// </summary>
    public static Vacation FullPastDays(int days, int id = 1)
    {
        var until = DateTime.Today.AddDays(-1);
        var since = until.AddDays(-days);
        return new Vacation
        {
            Id = id,
            DateSince = since,
            DateUntil = until,
            IsPartialVacation = false,
            NumberOfHours = 0
        };
    }

    // ---- Context builder ----

    /// <summary>
    /// Creates a minimal, self-contained EmployeeVacationContext with one employee, a package, and provided vacations.
    /// </summary>
    public static EmployeeVacationContext Context(int grantedDays, params Vacation[] vacations)
    {
        var employee = new Employee { Id = 1, Name = "User" };
        var package = new VacationPackage { Id = 1, Name = "Standard", GrantedDays = grantedDays, Year = DateTime.Today.Year };

        foreach (var v in vacations) { v.Employee = employee; v.EmployeeId = employee.Id; }

        return new EmployeeVacationContext
        {
            Employee = employee,
            VacationPackage = package,
            Vacations = [.. vacations]
        };
    }
}
