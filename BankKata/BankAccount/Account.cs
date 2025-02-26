namespace BankAccount;
 
public class Account : AccountService {
 
    private List<Transaction> BankStatement;
    private DateProvider dateProvider;
 
    public Account(DateProvider dateProvider) {
        BankStatement = new List<Transaction>();
        this.dateProvider = dateProvider;
    }
 
    public void deposit(int amount) {
        BankStatement.Add(new Transaction(dateProvider.Date, amount));
    }
 
    public void withdraw(int amount) {
        BankStatement.Add(new Transaction(dateProvider.Date, -amount));
    }
 
    public void printStatement() {
        System.Console.WriteLine("Date || Amount || Balance");
 
        orderByDateTime();
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

    private void orderByDateTime() {
        BankStatement.Sort((x, y) => x.Date.CompareTo(y.Date));
    }
}