namespace BankAccountOutsideIn;

public class Account : AccountService
{
    public int Balance {get;set;}
    private TransactionRepository transactionRepository;
    public Account(TransactionRepository transactionRepository){
        Balance = 0;
        this.transactionRepository = transactionRepository;
    }
    public void deposit(int amount)
    {
        Balance += amount;
    }

    public void printStatement()
    {
        throw new NotImplementedException();
    }

    public void withdraw(int amount)
    {
        Balance -= amount;
    }
}