using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplo_RecruitmentProject.Core.Models;
public class VacationPackage
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Number of vacation days granted in this package
    public int GrantedDays { get; set; }

    // Year for which the vacation package is valid
    public int Year { get; set; }

    // List of employees assigned to this package (optional, used for navigation)
    public virtual ICollection<Employee> Employees { get; set; } = [];
}
