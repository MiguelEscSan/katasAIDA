using Shouldly;
using NSubstitute;

namespace BankAccountOutsideIn.Test;

public class TransactionRepositoryShould {

    TransactionRepository transactionRepository;
    Account account;
    DateProvider dateProvider;
    Printer printer;

    [SetUp]
    public void SetUp() {
        transactionRepository = new InMemoryTransactionRepository();
    }

    [Test]
    public void save_the_received_transaction_in_transactions() {
        var date = new DateTime(2028, 2, 26);
        int amount = 50;
        Transaction transaction = new Transaction(date, amount);
       
    }
}