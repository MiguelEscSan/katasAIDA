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
        dateProvider = Substitute.For<DateProvider>();
        printer = Substitute.For<Printer>();
        transactionRepository = new InMemoryTransactionRepository();
        account = Substitute.For<Account>(transactionRepository, dateProvider, printer);
    }

    [Test]
    public void save_the_received_transaction_in_transactions() {
        var date = new DateTime(2028, 2, 26);

        dateProvider.GetDate().Returns(date);
        int amount = 50;
        account.deposit(amount);
        Transaction transaction = new Transaction(date, amount);

        transactionRepository.Received().Save(transaction);
    }
}