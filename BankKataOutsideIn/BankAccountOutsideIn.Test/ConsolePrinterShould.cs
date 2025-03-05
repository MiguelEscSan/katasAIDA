using Shouldly;
using NSubstitute;
using System.IO;

namespace BankAccountOutsideIn.Test;

public class ConsolePrinterShould {

    ConsolePrinter printer; 
    StringWriter stringWriter;
    
    [SetUp]
    public void Setup() {
        
        printer = new ConsolePrinter();
        stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
    }

    [TearDown]
    public void TearDown() {
        stringWriter.Dispose();
    }

    [Test]
    public void print_the_bank_statement_of_an_empty_account() {
        
        printer.Print(new List<StatementRow>());

        string actualOutput = stringWriter.ToString();
        string expectedOutput = "Date || Amount || Balance\r\n";
        actualOutput.ShouldBe(expectedOutput); 
    }

    [Test]
    public void print_the_bank_statement_of_an_account_with_transactions() {
    
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

        printer.Print(statementRows);

        string actualOutput = stringWriter.ToString();
        string expectedOutput = "Date || Amount || Balance\r\n14/01/2012 || -500 || 2500\r\n13/01/2012 || 2000 || 3000\r\n10/01/2012 || 1000 || 1000\r\n";
        actualOutput.ShouldBe(expectedOutput); 
    }
}
