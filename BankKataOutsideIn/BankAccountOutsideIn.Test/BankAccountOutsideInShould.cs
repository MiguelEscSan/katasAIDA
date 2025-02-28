using Shouldly;
using NSubstitute;
using System.Runtime.CompilerServices;

namespace BankAccountOutsideIn.Test;

public class BankAccountOutsideInShould
{
    Account account;
    TransactionRepository transactionRepository;
    DateProvider dateProvider;
    Printer printer;

    [SetUp]
    public void Setup()
    {
        transactionRepository = Substitute.For<TransactionRepository>();
        dateProvider = Substitute.For<DateProvider>();
        printer =  Substitute.For<Printer>();
        account =  new Account(transactionRepository, dateProvider, printer);
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
        var date = new DateTime(2028, 2, 26);

        dateProvider.GetDate().Returns(date);
        account.deposit(50);
        var validation = Arg.Is<Transaction>(item => item.Amount == 50 && item.Date == date);

        transactionRepository.Received().Save(validation);
    }

    [Test]
    public void create_new_transaction_when_withdrawing(){
        var date = new DateTime(2028, 2, 26);

        dateProvider.GetDate().Returns(date);
        account.withdraw(50);
        var validation = Arg.Is<Transaction>(item => item.Amount == -50 && item.Date == date);

        transactionRepository.Received().Save(validation);
    }

    [Test]
    public void create_multiple_transactions_when_depositing_and_withdrawing(){
        var date = new DateTime(2028, 2, 26);

        dateProvider.GetDate().Returns(date);
        account.withdraw(50);
    
        var validation = Arg.Is<Transaction>(item => item.Amount == -50 && item.Date == date);

        transactionRepository.Received().Save(validation);

        date = new DateTime(2028, 2, 27);

        dateProvider.GetDate().Returns(date);
        account.deposit(50);
    
        validation = Arg.Is<Transaction>(item => item.Amount == 50 && item.Date == date);

        transactionRepository.Received().Save(validation);

        account.Balance.ShouldBe(0);
    }

    [Test]
    public void print_only_the_header_of_the_bank_statement_when_account_is_empty(){
        
        List<StatementRow> statementRows = new List<StatementRow>();
        account.printStatement();

        // var validation = Arg.Is<List<StatementRow>>(statementRow => statementRow == null );

        printer.Received().Print(statementRows);
    }
}
