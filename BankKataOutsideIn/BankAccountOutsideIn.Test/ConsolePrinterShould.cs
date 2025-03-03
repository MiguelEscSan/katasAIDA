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

}