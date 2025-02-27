using Shouldly;
using System;
using System.IO;

namespace BankAccount.Test;

public class BankAccountShould
{
    DateProvider dateProvider;
    Account NewAccount;
    Printer printer;
    TransactionRepository transactionRepository;

    [SetUp]
    public void Setup()
    {
        dateProvider = new DateProvider();
        transactionRepository = new InMemoryTransactionRepository();
        printer = new ConsolePrinter();
        NewAccount = new Account(dateProvider, printer, transactionRepository);
    }

    private string PrintActualOutput() {
        string ActualOutput = "";
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        NewAccount.printStatement();
        ActualOutput = stringWriter.ToString(); 
        stringWriter.Dispose();
        return ActualOutput; 
    }

    [Test]
    public void give_empty_when_there_is_no_money_at_the_account() {
        string ActualOutput = PrintActualOutput();
        string ExpectedOutput = "Date || Amount || Balance\r\n";

        ActualOutput.ShouldBe(ExpectedOutput);
    }

    [Test]
    public void return_the_same_amount_as_deposited_in_an_empty_account(){
        dateProvider.Date = new DateTime(2025, 2, 26);
        NewAccount.deposit(50);

        string ActualOutput = PrintActualOutput();
        string ExpectedOutput = "Date || Amount || Balance\r\n26/02/2025 || 50 || 50\r\n";

        ActualOutput.ShouldBe(ExpectedOutput);
    }

    [Test]
    public void increase_balance_when_doing_multiple_deposits(){
        dateProvider.Date = new DateTime(2025, 2, 26);
        NewAccount.deposit(50);
        NewAccount.deposit(70);

        string ActualOutput = PrintActualOutput();     
        string ExpectedOutput = "Date || Amount || Balance\r\n26/02/2025 || 70 || 120\r\n26/02/2025 || 50 || 50\r\n";

        ActualOutput.ShouldBe(ExpectedOutput);
    }

    [Test]
    public void decrease_balance_when_withdrawing_money() {
        dateProvider.Date = new DateTime(2025, 2, 26);
        NewAccount.deposit(70);
        NewAccount.withdraw(50);

        string ActualOutput = PrintActualOutput();
        string ExpectedOutput = "Date || Amount || Balance\r\n26/02/2025 || -50 || 20\r\n26/02/2025 || 70 || 70\r\n";

        ActualOutput.ShouldBe(ExpectedOutput);
    }

    [Test]
    public void be_in_negative_when_withdrawing_more_money_than_the_account_has(){
        dateProvider.Date = new DateTime(2025, 2, 26);
        NewAccount.deposit(50);
        NewAccount.withdraw(70);

        string ActualOutput = PrintActualOutput();
        string ExpectedOutput = "Date || Amount || Balance\r\n26/02/2025 || -70 || -20\r\n26/02/2025 || 50 || 50\r\n";

        ActualOutput.ShouldBe(ExpectedOutput);
    }

    [Test]
    public void order_when_the_actions_its_made_in_different_days() {
        dateProvider.Date = new DateTime(2012, 1, 10);
        NewAccount.deposit(1000);

        dateProvider.Date = new DateTime(2012, 1, 13);
        NewAccount.deposit(2000);

        dateProvider.Date = new DateTime(2012, 1, 14);
        NewAccount.withdraw(500);

        string ActualOutput = PrintActualOutput();
        string ExpectedOutput = "Date || Amount || Balance\r\n14/01/2012 || -500 || 2500\r\n13/01/2012 || 2000 || 3000\r\n10/01/2012 || 1000 || 1000\r\n";

        ActualOutput.ShouldBe(ExpectedOutput);
    }
}
