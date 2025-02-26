namespace BankAccount;

public interface TransactionRepository {
    List<Transaction> GetAllTransactions();
    List<Transaction> orderByDateTime();
    void Save(Transaction transaction);
}