using System.Text;
 
namespace BankAccountOutsideIn;
 
public class ConsolePrinter: Printer{
    private StringBuilder output = new StringBuilder();
 
    public void Print(List<StatementRow> StatementInformation) {
        output.AppendLine("Date || Amount || Balance");
        for (int index = StatementInformation.Count - 1; index >= 0; index--) {
            output.AppendLine($"{FormatTransaction(StatementInformation[index].transaction)} || {StatementInformation[index].CurrentBalance}");
        }
        string finalOutput = output.ToString().TrimEnd(); 
        System.Console.WriteLine(finalOutput.ToString());
    }

     private string FormatTransaction(Transaction transaction) {
        return $"{FormatDate(transaction.Date)} || {transaction.Amount}";
    }
    private string FormatDate(DateTime Date) {
        return Date.ToString("dd/MM/yyyy");
    }
}
 