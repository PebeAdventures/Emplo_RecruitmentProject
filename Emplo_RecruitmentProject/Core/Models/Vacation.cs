using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplo_RecruitmentProject.Core.Models;
public class Vacation
{
    public int Id { get; set; }

    // Vacation start date
    public DateTime DateSince { get; set; }

    // Vacation end date
    public DateTime DateUntil { get; set; }

    // Total number of vacation hours (can be used for partial vacations)
    public int NumberOfHours { get; set; }

    // Indicates if the vacation is partial (not a full day)
    public bool IsPartialVacation { get; set; }

    // Employee who submitted the vacation request
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
