using AutoFixture;
using FluentAssertions;
using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Repository;
using hangi_kredi_restful.Services;
using HangiKredi.API.Loan.Exceptions;
using Moq;

namespace HangiKredi.Test;

public class LoanTest
{
    private readonly Fixture _fixture = new();
    private readonly Mock<ILoanRepository> _loanRepositoryMock = new();

    [Fact]
    public void When_IncreaseRateIsEqualOrLowerThanZero_ThrowException()
    {
        // Arrange  
        Loan loan = new();
        decimal increaseRate = 0;
        loan.Rate = 10.0m; // Set an initial rate for testing  
                           // Act  
        Action loanAction = () => { loan.IncreaseRate(increaseRate); };

        // Assert  
        loanAction.Should().ThrowExactly<LoanException>();
    }

    [Fact]
    public void When_IncreaseRateIsValid_DontThrowException()
    {
        // Arrange  
        Loan loan = new();
        decimal increaseRate = 1.0m;
        loan.Rate = 10.0m; // Set an initial rate for testing  
                           // Act  
        Action loanAction = () => { loan.IncreaseRate(increaseRate); };

        // Assert  
        loanAction.Should().NotThrow();
    }

    [Fact]
    public async Task When_CreateValid_DontThrowException()
    {
        // Arrange  
        _loanRepositoryMock.Setup(x => x.CreateLoan(It.IsAny<Loan>())).Returns(Task.CompletedTask);

        ILoanService loanService = new LoanService(_loanRepositoryMock.Object, null);
        Loan testLoan = _fixture.Create<Loan>();

        // Act  
        Func<Task> loanAction = async () => await loanService.CreateLoan(testLoan);

        // Assert  
        await loanAction.Should().NotThrowAsync();
    }
}
