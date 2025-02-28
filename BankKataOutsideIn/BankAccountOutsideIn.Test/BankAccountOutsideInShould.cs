using Shouldly;

namespace BankAccountOutsideIn.Test;

public class BankAccountOutsideInShould
{
    Account account;
    TransactionRepository transactionRepository;
    [SetUp]
    public void Setup()
    {
        account =  new Account(transactionRepository);
        
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
    [Test]
    public void return_negative_balance_when_withdrawing_an_empty_account(){
        var expectedBalance = -50;

        account.withdraw(50);

        account.Balance.ShouldBe(expectedBalance);
    }

    [Test]
    public void increase_balance_when_doing_multiple_deposits(){
        var expectedBalance =120;

        account.deposit(50);
        account.deposit(70);


        account.Balance.ShouldBe(expectedBalance);
    }
    [Test]
    public void decrease_balance_when_doing_multiple_withdraws(){
        var expectedBalance =-120;

        account.withdraw(50);
        account.withdraw(70);


        account.Balance.ShouldBe(expectedBalance);
    }

    [Test]
    public void create_new_transaction_when_depositing(){
        account.deposit(50);

    }

}
