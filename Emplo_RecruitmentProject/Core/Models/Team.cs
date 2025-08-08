namespace Emplo_RecruitmentProject.Core.Models;
public class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // List of employees assigned to this team
    public virtual ICollection<Employee> Employees { get; set; } = [];
}
