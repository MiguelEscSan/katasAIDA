namespace BankAccountOutsideIn;

public class Account : AccountService
{
    private TransactionRepository transactionRepository;
    private DateProvider dateProvider;
    private Printer printer;
    public Account(TransactionRepository transactionRepository, DateProvider dateProvider, Printer printer) {
        this.transactionRepository = transactionRepository;
        this.dateProvider = dateProvider;
        this.printer = printer;
    }
    public void deposit(int amount) {
        transactionRepository.Save(new Transaction(dateProvider.GetDate(), amount));
    }

    public void withdraw(int amount) {
        transactionRepository.Save(new Transaction(dateProvider.GetDate(), -amount));
    }

    public void printStatement() {
        var sortedTransactions = transactionRepository.OrderByDateTime();
        var statementsInfo = GetTransactionsWithBalances(sortedTransactions);
        this.printer.Print(statementsInfo);
    }

    private List<StatementRow> GetTransactionsWithBalances( List<Transaction> SortedTransactions) {
        int currentBalance = 0;     
        return SortedTransactions
                .Select(transaction => {  
                    currentBalance += transaction.Amount;
                    return new StatementRow(transaction, currentBalance); 
                }).ToList();       
    } 
    
}