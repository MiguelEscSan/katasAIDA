using Shouldly;

namespace BankAccountOutsideIn.Test;

public class BankAccountOutsideInShould
{
    Account account;
    [SetUp]
    public void Setup()
    {
        account =  new Account();
    }

    [Test]
    public void return_empty_balance_when_account_is_created()
    {
        var expectedBalance = 0;
        account.Balance.ShouldBe(expectedBalance);
    }

    [Test]
    public void return_correct_balance_when_depositing(){
        var expectedBalance = 50;
        
        account.deposit(50);

        account.Balance.ShouldBe(expectedBalance);

    }
}
