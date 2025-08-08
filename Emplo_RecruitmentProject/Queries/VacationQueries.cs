using Emplo_RecruitmentProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Emplo_RecruitmentProject.Queries;
public class VacationQueries
{
    private readonly DbContext _context;

    public VacationQueries(DbContext context) => _context = context;

    /// <summary>
    /// Returns employees from the specified team who had at least one vacation in the given year.
    /// </summary>
    public async Task<List<Employee>> GetEmployeesWithVacationsByTeamAndYearAsync(string teamName, int year)
    {
        return await _context.Set<Employee>()
            .Include(e => e.Team)
            .Include(e => e.Vacations)
            .Where(e => e.Team.Name == teamName)
            .Where(e => e.Vacations.Any(v =>
                v.DateSince.Year == year || v.DateUntil.Year == year))
            .ToListAsync();
    }
    /// <summary>
    /// Returns employees along with the number of used vacation days (only full vacations, already past).
    /// </summary>
    public async Task<List<(Employee Employee, int UsedDays)>> GetUsedVacationDaysForCurrentYearAsync()
    {
        var currentDate = DateTime.Today;

        var employees = await _context.Set<Employee>()
            .Include(e => e.Vacations)
            .ToListAsync();

        var result = employees.Select(e =>
        {
            var usedDays = e.Vacations
                .Where(v => !v.IsPartialVacation && v.DateUntil < currentDate)
                .Sum(v => (int)(v.DateUntil - v.DateSince).TotalDays);

            return (e, usedDays);
        }).ToList();

        return result;
    }
    /// <summary>
    /// Returns teams whose employees have not submitted any vacation in the specified year.
    /// </summary>
    public async Task<List<Team>> GetTeamsWithoutVacationsInYearAsync(int year)
    {
        return await _context.Set<Team>()
            .Include(t => t.Employees)
                .ThenInclude(e => e.Vacations)
            .Where(team => !team.Employees
                .SelectMany(e => e.Vacations)
                .Any(v => v.DateSince.Year == year || v.DateUntil.Year == year))
            .ToListAsync();
    }

}
