namespace BankAccountOutsideIn;
public interface TransactionRepository {
    List<Transaction> GetAllTransactions();
    List<Transaction> OrderByDateTime();
    void Save(Transaction transaction);
}