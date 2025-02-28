namespace BankAccountOutsideIn;

public class Account : AccountService
{
    public int Balance {get;set;}
    private TransactionRepository transactionRepository;
    private DateProvider dateProvider;
    private Printer printer;
    public Account(TransactionRepository transactionRepository, DateProvider dateProvider, Printer printer){
        Balance = 0;
        this.transactionRepository = transactionRepository;
        this.dateProvider = dateProvider;
        this.printer = printer;
    }
    public void deposit(int amount)
    {
        transactionRepository.Save(new Transaction(dateProvider.GetDate(), amount));
        Balance += amount;
    }

     public void printStatement() {
        List<StatementRow> StatementInformation = GetPrintStatementInformation();
        printer.Print(StatementInformation);
    }

    private List<StatementRow> GetPrintStatementInformation() {
        // var SortedTransactions = transactionRepository.orderByDateTime();
         var SortedTransactions = orderByDateTime();
        return GetTransactionsWithBalances(SortedTransactions);
    }

    private List<StatementRow> GetTransactionsWithBalances( List<Transaction> SortedTransactions) {

        int currentBalance = 0;     
        return SortedTransactions.Any()?SortedTransactions
                .Select(transaction => {  
                    currentBalance += transaction.Amount;
                    return new StatementRow(transaction, currentBalance); 
                }).ToList(): new List<StatementRow>();
                
    }

    public void withdraw(int amount)
    {
        transactionRepository.Save(new Transaction(dateProvider.GetDate(), -amount));
        Balance -= amount;
    }
     public List<Transaction> orderByDateTime() {
        var SortedTransactions = new List<Transaction>(transactionRepository.GetAllTransactions());
        SortedTransactions.Sort((x, y) => x.Date.CompareTo(y.Date));
        return SortedTransactions;
    }
}