namespace BankAccount;

public class ConsolePrinter: Printer{

    public void Print(List<(Transaction,int)> StatementInformation){
        System.Console.WriteLine("Date || Amount || Balance");
        for(int transaction = StatementInformation.Count - 1; transaction >= 0; transaction--) {
            System.Console.WriteLine($"{StatementInformation[transaction].Item1.ToString()} || {StatementInformation[transaction].Item2}");
        }
    }
}