namespace BankAccount;

public class ConsolePrinter: Printer{

    public void Print(List<StatementRow> StatementInformation){
        System.Console.WriteLine("Date || Amount || Balance");
        for(int transaction = StatementInformation.Count - 1; transaction >= 0; transaction--) {
            System.Console.WriteLine($"{FormatTransaction(StatementInformation[transaction].transaction)} || {StatementInformation[transaction].CurrentBalance}");
        }
    }

    public string FormatTransaction(Transaction transaction) {
        return $"{FormatDate(transaction.Date)} || {transaction.Amount}";
    }
    public string FormatDate(DateTime Date) {
        return Date.ToString("dd/MM/yyyy");
    }
}