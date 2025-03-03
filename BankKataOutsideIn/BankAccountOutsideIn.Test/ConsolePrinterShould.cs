using Shouldly;
using NSubstitute;

namespace BankAccountOutsideIn.Test;

public class ConsolePrinterShould {

    ConsolePrinter printer; 
    
    [SetUp]
    public void Setup() {
        printer = new ConsolePrinter();
    }

    [Test]
    public void print_the_bank_statement_of_an_empty_account() {
        string expecetedOutput = "Date || Amount || Balance\r\n";

        printer.Print([]);
        string ActualOutput = printer.GetPrintedContent();

        ActualOutput.ShouldBe(expecetedOutput);
    }

    [Test]

    public void print_the_bank_statement_of_an_account_with_transactions(){
        string expecetedOutput = "Date || Amount || Balance\r\n14/01/2012 || -500 || 2500\r\n13/01/2012 || 2000 || 3000\r\n10/01/2012 || 1000 || 1000\r\n";

        List<Transaction> transactionRows = [ 
            new Transaction(new DateTime(2012, 1,10), 1000),
            new Transaction(new DateTime(2012, 1,13), 2000),
            new Transaction(new DateTime(2012, 1,14), -500),
        ];
        List<StatementRow> statementRows = [
            new StatementRow(transactionRows[0], 1000),
            new StatementRow(transactionRows[1], 3000),
            new StatementRow(transactionRows[2], 2500),
        ];
        printer.Print(statementRows);
        string ActualOutput = printer.GetPrintedContent();

        ActualOutput.ShouldBe(expecetedOutput);
    
    }

}