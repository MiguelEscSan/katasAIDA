namespace BankAccount;

public class Account : AccountService {

    List<Transaction> BankStatement;
    int Balance;

    public Account() {
        BankStatement = new List<Transaction>();
        Balance = 0;
    }

    public void deposit(int amount) {
        
    }


    public void withdraw(int amount) {

    }

    public void printStatement() {
        System.Console.WriteLine("Date || Amount || Balance");
    }
}