using FluentAssertions;
using HomeWorkExample.Application.CustomerSalaries.Commands.UpdateBaseSalaryCommand;
using HomeWorkExample.Interfaces;
using HomeWorkExample.Models;
using Moq;
using Xunit;

namespace HomeWorkExample.UnitTests.CustomerSalaries;

public class UpdateBaseSalaryTests
{
    [Fact]
    public async Task ShouldUpdate_BaseSalary()
    {
        var repository = new Mock<ISalaryRepository>();
        repository.Setup(i => i.GetCustomerSalary(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((long customerId, CancellationToken _) => new CustomerSalary
            {
                CustomerId = customerId,
                BasicSalary = 30
            });

        var request = new UpdateBaseSalaryCommandRequest(7, 100);
        var handler = new UpdateBaseSalaryCommandHandler(repository.Object);

        await FluentActions.Invoking(async () => await handler.Handle(request, new CancellationToken()))
            .Should().NotThrowAsync();
        repository.Verify(i => i.UpdateCustomerBaseSalary(It.IsAny<CustomerSalary>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}