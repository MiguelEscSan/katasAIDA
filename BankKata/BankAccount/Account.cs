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
        if(BankStatement.Count == 0) return;
        BankStatement.Add(new Transaction(-amount));
    }
 
    public void printStatement() {
        System.Console.WriteLine("Date || Amount || Balance");
 
        List<int> CurrentBalances = CalculateCurrentBalances();
 
        for(int i = BankStatement.Count - 1; i >= 0; i--) {
            System.Console.WriteLine($"{BankStatement[i].ToString()} || {CurrentBalances[i]}");
        }
    }
 
    private List<int> CalculateCurrentBalances() {
        List<int> Balances = new List<int>();
        int amount = 0;
        foreach (Transaction transaction in BankStatement) {
            amount += transaction.Amount;
            Balances.Add(amount);
        }
        return Balances;
    }
}