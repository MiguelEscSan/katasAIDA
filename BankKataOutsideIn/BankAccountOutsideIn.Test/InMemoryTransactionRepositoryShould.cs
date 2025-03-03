using Shouldly;
using NSubstitute;

namespace BankAccountOutsideIn.Test;

public class    InMemoryTransactionRepositoryShould {

    InMemoryTransactionRepository transactionRepository;

    [SetUp]
    public void SetUp() {
        transactionRepository = new InMemoryTransactionRepository();
    }

    [Test]
    public void save_the_received_transaction_in_transactions() {
        var date = new DateTime(2028, 2, 26);
        int amount = 50;
        Transaction transaction = new Transaction(date, amount);
        var expectedTransactions = new List<Transaction>{transaction};
        
        transactionRepository.Save(transaction);

        transactionRepository.Transactions.ShouldBe(expectedTransactions);
    }

    [Test]
    public void return_sorted_transactions_by_date() {
        var date = new DateTime(2028, 2, 26);
        int amount = 50;
        Transaction transaction1 = new Transaction(date, amount);
        date = new DateTime(2028, 2, 23);
        Transaction transaction2 = new Transaction(date, amount);
        date = new DateTime(2028, 2, 27);
        Transaction transaction3 = new Transaction(date, amount);
        var expectedTransactions = new List<Transaction>{transaction2, transaction1, transaction3};
        
        transactionRepository.Save(transaction3);
        transactionRepository.Save(transaction2);
        transactionRepository.Save(transaction1);        

        transactionRepository.GetAll().ShouldBe(expectedTransactions);
    }
}