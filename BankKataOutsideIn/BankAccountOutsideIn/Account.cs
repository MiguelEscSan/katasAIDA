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
        var statementRows = transactionRepository
            .orderByDateTime()
            .Select(transaction => {
                return new StatementRow(null, 0);
            }).ToList();
        this.printer.Print(statementRows);
    }


    public void withdraw(int amount)
    {
        transactionRepository.Save(new Transaction(dateProvider.GetDate(), -amount));
        Balance -= amount;
    }
}