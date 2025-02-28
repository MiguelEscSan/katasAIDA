namespace BankAccountOutsideIn;

public class Account : AccountService
{
    public int Balance {get;}

    public Account(){
        Balance = 0;
    }
    public void deposit(int amount)
    {
        throw new NotImplementedException();
    }

    public void printStatement()
    {
        throw new NotImplementedException();
    }

    public void withdraw(int amount)
    {
        throw new NotImplementedException();
    }
}