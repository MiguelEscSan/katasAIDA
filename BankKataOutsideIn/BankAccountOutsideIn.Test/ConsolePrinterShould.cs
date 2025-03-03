using Shouldly;
using NSubstitute;
using System.IO;

namespace BankAccountOutsideIn.Test;

public class ConsolePrinterShould {

    ConsolePrinter printer; 
    
    [SetUp]
    public void Setup() {
        printer = new ConsolePrinter();
    }

    private string CaptureConsoleOutput(Action printAction) {
        var originalOutput = Console.Out;
        var stringWriter = new StringWriter();
        
        Console.SetOut(stringWriter);

        printAction();

        Console.SetOut(originalOutput);
        stringWriter.Dispose();

        return stringWriter.ToString();
        
    }

    [Test]
    public void print_the_bank_statement_of_an_empty_account() {
        string expectedOutput = "Date || Amount || Balance\r\n";

        string actualOutput = CaptureConsoleOutput(() => printer.Print(new List<StatementRow>()));

        actualOutput.ShouldBe(expectedOutput); 
    }

    [Test]
    public void print_the_bank_statement_of_an_account_with_transactions() {
        string expectedOutput = "Date || Amount || Balance\r\n14/01/2012 || -500 || 2500\r\n13/01/2012 || 2000 || 3000\r\n10/01/2012 || 1000 || 1000\r\n";


        List<Transaction> transactionRows = new List<Transaction> 
        { 
            new Transaction(new DateTime(2012, 1,10), 1000),
            new Transaction(new DateTime(2012, 1,13), 2000),
            new Transaction(new DateTime(2012, 1,14), -500),
        };
        
        List<StatementRow> statementRows = new List<StatementRow>
        {
            new StatementRow(transactionRows[0], 1000),
            new StatementRow(transactionRows[1], 3000),
            new StatementRow(transactionRows[2], 2500),
        };

        // Capturamos la salida de la consola
        string actualOutput = CaptureConsoleOutput(() => printer.Print(statementRows));

        actualOutput.ShouldBe(expectedOutput);
    }
}
