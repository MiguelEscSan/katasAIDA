namespace BankAccount;

public interface TransactionRepository {
    List<Transaction> GetAll();
    List<Transaction> orderByDateTime();
    void Save(Transaction transaction);
}