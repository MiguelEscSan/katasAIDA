namespace BankAccountOutsideIn;

public class Account : AccountService
{
    public int Balance {get;set;}

    public Account(){
        Balance = 0;
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