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

        string ActualOutput = "";
        string ExpectedOutput = "";
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            NewAccount.printStatement();
            ActualOutput = stringWriter.ToString();

            
        }
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            System.Console.WriteLine("Date || Amount || Balance");
            ExpectedOutput = stringWriter.ToString();     
        }

        ActualOutput.ShouldBe(ExpectedOutput);
        Console.SetOut(Console.Out);
    }

    [Test]
    public void give_50_when_depositing_50(){
        var NewAccount = new Account();
        NewAccount.deposit(50);

        string ActualOutput = "";
        string ExpectedOutput = "";
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            NewAccount.printStatement();
            ActualOutput = stringWriter.ToString();
        }
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            System.Console.WriteLine("Date || Amount || Balance");
            System.Console.WriteLine("25/02/2025 || 50 || 50");
            ExpectedOutput = stringWriter.ToString();     
        }

        ActualOutput.ShouldBe(ExpectedOutput);

        Console.SetOut(Console.Out);
    }


    [Test]
    public void give_120_when_depositing_50_and_70(){
        var NewAccount = new Account();
        NewAccount.deposit(50);
        NewAccount.deposit(70);

        string ActualOutput = "";
        string ExpectedOutput = "";
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            NewAccount.printStatement();
            ActualOutput = stringWriter.ToString();
        }
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            System.Console.WriteLine("Date || Amount || Balance");
            System.Console.WriteLine("25/02/2025 || 70 || 120");
            System.Console.WriteLine("25/02/2025 || 50 || 50");
            ExpectedOutput = stringWriter.ToString();     
        }

        ActualOutput.ShouldBe(ExpectedOutput);

        Console.SetOut(Console.Out);
    }

    [Test]
    public void give_20_when_withdrawing_50_and_balance_is_70(){
        var NewAccount = new Account();
        NewAccount.deposit(70);
        NewAccount.withdraw(50);

        string ActualOutput = "";
        string ExpectedOutput = "";
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            NewAccount.printStatement();
            ActualOutput = stringWriter.ToString();
        }
        using(StringWriter stringWriter = new StringWriter()) {
            Console.SetOut(stringWriter);
            System.Console.WriteLine("Date || Amount || Balance");
            System.Console.WriteLine("25/02/2025 || -50 || 20");
            System.Console.WriteLine("25/02/2025 || 70 || 70");
            ExpectedOutput = stringWriter.ToString();     
        }

        ActualOutput.ShouldBe(ExpectedOutput);

        Console.SetOut(Console.Out);
    }

    [Test]
    public void not_allow_to_withdraw_from_an_empty_account(){

        var NewAccount = new Account();
            NewAccount.withdraw(50);

            string ActualOutput = "";
            string ExpectedOutput = "";
            using(StringWriter stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                NewAccount.printStatement();
                ActualOutput = stringWriter.ToString();
            }
            using(StringWriter stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                System.Console.WriteLine("Date || Amount || Balance");
                ExpectedOutput = stringWriter.ToString();     
            }

            ActualOutput.ShouldBe(ExpectedOutput);

            Console.SetOut(Console.Out);
    }
    

}
