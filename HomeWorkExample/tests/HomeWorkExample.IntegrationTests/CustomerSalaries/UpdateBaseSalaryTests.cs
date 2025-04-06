using FluentAssertions;
using HomeWorkExample.Application.CustomerSalaries.Commands.UpdateBaseSalaryCommand;
using HomeWorkExample.IntegrationTests.Tools;
using HomeWorkExample.Interfaces;
using HomeWorkExample.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace HomeWorkExample.IntegrationTests.CustomerSalaries;

public class UpdateBaseSalaryTests : IClassFixture<CustomWebFactory<Program>>
{
    private readonly CustomWebFactory<Program> _factory;

    public UpdateBaseSalaryTests(CustomWebFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ShouldUpdate_BaseSalary()
    {
        using var scope = _factory.Services.CreateScope();
        var repository = scope.ServiceProvider.GetService<ISalaryRepository>()!;
        var cancellationToken = new CancellationToken();

        await repository.AddCustomerSalary(new CustomerSalary
        {
            CustomerId = 7,
            BasicSalary = 30,
            Id = 123,
            Rate = 1
        }, cancellationToken);
        
        var request = new UpdateBaseSalaryCommandRequest(7, 100);
        var handler = new UpdateBaseSalaryCommandHandler(repository);

        await FluentActions.Invoking(async () => await handler.Handle(request, cancellationToken))
            .Should().NotThrowAsync();

        var salary = await repository.GetCustomerSalary(7, cancellationToken);
        salary.Should().NotBeNull();
        salary.BasicSalary.Should().Be(100);
    }
}