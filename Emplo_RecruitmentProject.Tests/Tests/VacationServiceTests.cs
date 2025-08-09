using Emplo_RecruitmentProject.Core.DTOs;
using Emplo_RecruitmentProject.Core.Models;
using Emplo_RecruitmentProject.Core.Services;
using static Emplo_RecruitmentProject.Tests.TestData.MockData;

namespace Emplo_RecruitmentProject.Tests.Tests;

public class VacationServiceTests
{
    [Fact]
    public void employee_can_request_vacation()
    {
        var ctx = Context(20, FullPastDays(5));
        var svc = new VacationService();

        var free = svc.CountFreeDaysForEmployee(ctx);
        var can = svc.CanRequestVacation(ctx);

        Assert.Equal(15, free);
        Assert.True(can);
    }

    [Fact]
    public void employee_cant_request_vacation()
    {
        var ctx = Context(10, FullPastDays(10));
        var svc = new VacationService();

        var free = svc.CountFreeDaysForEmployee(ctx);
        var can = svc.CanRequestVacation(ctx);

        Assert.Equal(0, free);
        Assert.False(can);
    }
}