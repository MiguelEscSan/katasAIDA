using Shouldly;
using System;
using System.IO;

namespace BankAccount.Test;

public class BankAccountShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void give_empty_when_there_is_no_money_at_the_account() {
        var NewAccount = new Account();
        var Expected = new Account();

        string ActualOutput = "";
        string ExpectedOutput = "";
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            NewAccount.printStatement();
            ActualOutput = stringWriter.ToString();

            
        }
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            Expected.printStatement();
            ExpectedOutput = stringWriter.ToString();
        } 
        // string ExpectedOutput = "Date || Amount || Balance\n";

        ActualOutput.ShouldBe(ExpectedOutput);

        Console.SetOut(Console.Out);
    }

    [Test]
    public void give_empty_when_depositing_zero(){
        var NewAccount = new Account();
        var Expected = new Account(){
            BankStatement = new List<Transaction>{
                new Transaction(0)
            }
        };
        NewAccount.deposit(0);
        string ActualOutput = "";
        string ExpectedOutput = "";
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            NewAccount.printStatement();
            ActualOutput = stringWriter.ToString();

            
        }
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            Expected.printStatement();
            ExpectedOutput = stringWriter.ToString();
        } 
        // string ExpectedOutput = "Date || Amount || Balance\n";

        ActualOutput.ShouldBe(ExpectedOutput);

        Console.SetOut(Console.Out);
    }




}
