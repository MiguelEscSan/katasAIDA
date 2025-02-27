namespace BankAccount;

public class ConsolePrinter: Printer{

    public void Print(List<StatementRow> StatementInformation){
        System.Console.WriteLine("Date || Amount || Balance");
        for(int index = StatementInformation.Count - 1; index >= 0; index--) {
            System.Console.WriteLine($"{FormatTransaction(StatementInformation[index].transaction)} || {StatementInformation[index].CurrentBalance}");
        }
    }

    private string FormatTransaction(Transaction transaction) {
        return $"{FormatDate(transaction.Date)} || {transaction.Amount}";
    }
    private string FormatDate(DateTime Date) {
        return Date.ToString("dd/MM/yyyy");
    }
}