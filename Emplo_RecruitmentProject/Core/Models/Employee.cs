using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplo_RecruitmentProject.Core.Models;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Self-referencing supervisor relationship (used in task 1)
    public int? SuperiorId { get; set; }

    public virtual Employee? Superior { get; set; }

    // Team assignment (used in task 2)
    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    // Vacation package assigned to the employee (tasks 3 and 4)
    public int VacationPackageId { get; set; }

    public virtual VacationPackage VacationPackage { get; set; } = null!;

    // List of vacation requests submitted by the employee
    public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
}
