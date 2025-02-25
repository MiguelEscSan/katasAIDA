namespace BankAccount;

public class Account : AccountService {

    public List<Transaction> BankStatement;

    public Account() {
        BankStatement = new List<Transaction>();
    }

    public void deposit(int amount) {
        BankStatement.Add(new Transaction(amount));
    }


    public void withdraw(int amount) {

    }

    public void printStatement() {
        System.Console.WriteLine("Date || Amount || Balance");
        List<int> CurrentBalances = new List<int>();
        int amount = 0;
        foreach (Transaction transaction in BankStatement) {
            amount += transaction.Amount;
            CurrentBalances.Add(amount);
        }

        for(int i = BankStatement.Count - 1; i >= 0; i--) {
            System.Console.WriteLine($"{BankStatement[i].ToString()} || {CurrentBalances[i]}");
        }



        // System.Console.WriteLine($"{transaction.ToString()} || {CurrentBalance}");
    }
}