using Shouldly;
using NSubstitute;

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
    public void print_an_empty_account(){

         List<Transaction> transactionRows = [];

        transactionRepository.orderByDateTime().Returns(transactionRows);

             
        account.printStatement();   

        var validation = Arg.Is<List<StatementRow>>(row => row.Count == 0);
        printer.Received().Print(validation);        
    }

    [Test]
    public void print_a_non_empty_account() {
        DateTime date = DateTime.Now;

        List<Transaction> transactionRows = [ 
            new Transaction(date, 1),
            new Transaction(date, 10)
        ];

        transactionRepository.orderByDateTime().Returns(transactionRows);

        account.printStatement();

        List<StatementRow> statementRows = [
            new StatementRow(transactionRows[0], 1),
            new StatementRow(transactionRows[1], 11)
        ];


        var validation = Arg.Is<List<StatementRow>>(list =>isTheSameList(list, statementRows));

        printer.Received().Print(validation); 
    }

    private bool isTheSameList(List<StatementRow> list1, List<StatementRow> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            var statement1 = list1[i];
            var statement2 = list2[i];

            if (IsSameTransaction(statement1.transaction, statement2.transaction) is false)
                return false;

            if (statement1.CurrentBalance != statement2.CurrentBalance)
                return false;
        }

        return true;
    }

    private bool IsSameTransaction(Transaction transaction1, Transaction transaction2)
    {
        return transaction1.Date == transaction2.Date && transaction1.Amount == transaction2.Amount;
    }

}
