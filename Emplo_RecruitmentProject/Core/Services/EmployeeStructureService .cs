using Emplo_RecruitmentProject.Core.DTOs;
using Emplo_RecruitmentProject.Core.Models;

namespace Emplo_RecruitmentProject.Core.Services;
public class EmployeeStructureService : IEmployeeStructureService
{
    private readonly Dictionary<int, List<EmployeeStructure>> _structureMap = new();
    public List<EmployeeStructure> FillEmployeesStructure(List<Employee> employees)
    {
        var result = new List<EmployeeStructure>();

        foreach (var employee in employees)
        {
            var current = employee;
            int level = 0;

            while (current.SuperiorId.HasValue)
            {
                level++;
                var superiorId = current.SuperiorId.Value;

                result.Add(new EmployeeStructure
                {
                    EmployeeId = employee.Id,
                    SuperiorId = superiorId,
                    Level = level
                });

                current = employees.FirstOrDefault(e => e.Id == superiorId);
                if (current == null) break;
            }
        }

        // map for quick access 
        _structureMap.Clear();
        foreach (var structure in result)
        {
            if (!_structureMap.ContainsKey(structure.EmployeeId))
                _structureMap[structure.EmployeeId] = new List<EmployeeStructure>();

            _structureMap[structure.EmployeeId].Add(structure);
        }

        return result;
    }

    public int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
    {
        if (_structureMap.TryGetValue(employeeId, out var relations))
        {
            var relation = relations.FirstOrDefault(r => r.SuperiorId == superiorId);
            return relation?.Level;
        }

        return null;
    }
}
