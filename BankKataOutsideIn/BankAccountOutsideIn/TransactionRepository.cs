namespace BankAccountOutsideIn;
public interface TransactionRepository {
    List<Transaction> GetAll();
    void Save(Transaction transaction);
}