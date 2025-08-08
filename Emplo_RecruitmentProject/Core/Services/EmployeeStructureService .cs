using Emplo_RecruitmentProject.Core.DTOs;
using Emplo_RecruitmentProject.Core.Models;

namespace Emplo_RecruitmentProject.Core.Services;
public class EmployeeStructureService : IEmployeeStructureService
{
    private readonly Dictionary<int, List<EmployeeStructure>> _structureMap = [];
    public List<EmployeeStructure> FillEmployeesStructure(List<Employee> employees)
    {
        var result = new List<EmployeeStructure>();

        foreach (var employee in employees)
        {
            var superiors = GetSuperiorsChain(employee, employees);
            result.AddRange(superiors);
        }
        BuildStructureMap(result);
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

    private void BuildStructureMap(List<EmployeeStructure> result)
    {
        _structureMap.Clear();
        foreach (var structure in result)
        {
            if (!_structureMap.ContainsKey(structure.EmployeeId))
                _structureMap[structure.EmployeeId] = new List<EmployeeStructure>();

            _structureMap[structure.EmployeeId].Add(structure);
        }
    }

    private List<EmployeeStructure> GetSuperiorsChain(Employee employee, List<Employee> employees)
    {
        var chain = new List<EmployeeStructure>();
        var current = employee;
        int level = 0;

        while (current.SuperiorId.HasValue)
        {
            level++;
            int superiorId = current.SuperiorId.Value;

            chain.Add(new EmployeeStructure
            {
                EmployeeId = employee.Id,
                SuperiorId = superiorId,
                Level = level
            });

            current = employees.FirstOrDefault(e => e.Id == superiorId);
            if (current == null) break;
        }

        return chain;
    }
}
