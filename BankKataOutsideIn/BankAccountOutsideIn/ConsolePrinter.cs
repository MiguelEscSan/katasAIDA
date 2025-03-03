using System.Text;
 
namespace BankAccountOutsideIn;
 
public class ConsolePrinter: Printer{
    private StringBuilder output = new StringBuilder();
 
    public void Print(List<StatementRow> StatementInformation) {
        output.AppendLine("Date || Amount || Balance");
        System.Console.WriteLine(GetPrintedContent());
    }
 
    public string GetPrintedContent() {
        return output.ToString();
    }
}
 