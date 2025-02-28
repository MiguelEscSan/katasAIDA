namespace BankAccountOutsideIn;

public class Account : AccountService
{
    public int Balance {get;set;}
    private TransactionRepository transactionRepository;
    private DateProvider dateProvider;
    public Account(TransactionRepository transactionRepository, DateProvider dateProvider){
        Balance = 0;
        this.transactionRepository = transactionRepository;
        this.dateProvider = dateProvider;
    }
    public void deposit(int amount)
    {
        transactionRepository.Save(new Transaction(dateProvider.GetDate(), amount));
        Balance += amount;
    }

    public void printStatement()
    {
        throw new NotImplementedException();
    }

    public void withdraw(int amount)
    {
        transactionRepository.Save(new Transaction(dateProvider.GetDate(), -amount));
        Balance -= amount;
    }
}