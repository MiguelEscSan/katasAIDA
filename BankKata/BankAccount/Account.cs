namespace BankAccount;
 
public class Account : AccountService {
 
    private List<Transaction> Transactions;
    private DateProvider dateProvider;
 
    public Account(DateProvider dateProvider) {
        Transactions = new List<Transaction>();
        this.dateProvider = dateProvider;
    }
 
    public void deposit(int amount) {
        Transactions.Add(new Transaction(dateProvider.Date, amount));
    }
 
    public void withdraw(int amount) {
        Transactions.Add(new Transaction(dateProvider.Date, -amount));
    }
 
    public void printStatement() {
        
        List<int> CurrentBalances = CalculateCurrentBalances();

        System.Console.WriteLine("Date || Amount || Balance");
        for(int i = Transactions.Count - 1; i >= 0; i--) {
            System.Console.WriteLine($"{Transactions[i].ToString()} || {CurrentBalances[i]}");
        }
    }
 
    private List<int> CalculateCurrentBalances() {
        orderByDateTime();

        List<int> Balances = new List<int>();
        int amount = 0;
        foreach (Transaction transaction in Transactions) {
            amount += transaction.Amount;
            Balances.Add(amount);
        }
        return Balances;
    }

    private void orderByDateTime() {
        Transactions.Sort((x, y) => x.Date.CompareTo(y.Date));
    }
}