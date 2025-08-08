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
    public int? SuperiorId { get; set; }
    public virtual Employee? Superior { get; set; }
}
