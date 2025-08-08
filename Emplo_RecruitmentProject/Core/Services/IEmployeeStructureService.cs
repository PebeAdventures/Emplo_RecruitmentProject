using Emplo_RecruitmentProject.Core.DTOs;
using Emplo_RecruitmentProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplo_RecruitmentProject.Core.Services;
public interface IEmployeeStructureService
{
    List<EmployeeStructure> FillEmployeesStructure(List<Employee> employees);
    int? GetSuperiorRowOfEmployee(int employeeId, int superiorId);
}
