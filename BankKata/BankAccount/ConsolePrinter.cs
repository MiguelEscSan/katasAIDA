namespace BankAccount;

public class ConsolePrinter: Printer{

    public void Print(List<(Transaction,int)> StatementInformation){
        System.Console.WriteLine("Date || Amount || Balance");
        for(int transaction = StatementInformation.Count - 1; transaction >= 0; transaction--) {
            System.Console.WriteLine($"{FormatTransaction(StatementInformation[transaction].Item1)} || {StatementInformation[transaction].Item2}");
        }
    }

    public string FormatTransaction(Transaction transaction) {
        return $"{FormatDate(transaction.Date)} || {transaction.Amount}";
    }
    public string FormatDate(DateTime Date) {
        return Date.ToString("dd/MM/yyyy");
    }
}