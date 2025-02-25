using System.Collections.Generic;
 
namespace BankAccount;

public class Account : AccountService {

    public Stack<Transaction> BankStatement;

    public Account() {
        BankStatement = new Stack<Transaction>();
    }

    public void deposit(int amount) {
        BankStatement.Push(new Transaction(amount));
    }


    public void withdraw(int amount) {

    }

    public void printStatement() {
        System.Console.WriteLine("Date || Amount || Balance");
        int CurrentBalance = 0;
        foreach (Transaction transaction in BankStatement) {
            CurrentBalance += transaction.Amount;
            System.Console.WriteLine($"{transaction.ToString()} || {CurrentBalance}");
        }
    }
}