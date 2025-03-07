﻿using Shouldly;
using NSubstitute;
namespace BankAccountOutsideIn.Test;

public class BankAccountOutsideInShould
{
    Account account;
    TransactionRepository transactionRepository;
    DateProvider dateProvider;
    Printer printer;

    [SetUp]
    public void Setup()
    {
        transactionRepository = Substitute.For<TransactionRepository>();
        dateProvider = Substitute.For<DateProvider>();
        printer =  Substitute.For<Printer>();
        account =  new Account(transactionRepository, dateProvider, printer);
    }

    [Test]
    public void create_new_transaction_when_depositing(){
        var date = new DateTime(2028, 2, 26);

        dateProvider.GetDate().Returns(date);
        account.deposit(50);
        var validation = Arg.Is<Transaction>(item => item.Amount == 50 && item.Date == date);

        transactionRepository.Received().Save(validation);
    }

    [Test]
    public void create_new_transaction_when_withdrawing(){
        var date = new DateTime(2028, 2, 26);

        dateProvider.GetDate().Returns(date);
        account.withdraw(50);
        var validation = Arg.Is<Transaction>(item => item.Amount == -50 && item.Date == date);

        transactionRepository.Received().Save(validation);
    }

    [Test]
    public void print_an_empty_account(){

         List<Transaction> transactionRows = [];

        transactionRepository.GetAll().Returns(transactionRows);

             
        account.printStatement();   

        var validation = Arg.Is<List<StatementRow>>(row => row.Count == 0);
        printer.Received().Print(validation);        
    }

    [Test]
    public void print_a_non_empty_account() {
        DateTime date = DateTime.Now;

        List<Transaction> transactionRows = [ 
            new Transaction(date, 1),
            new Transaction(date, 10)
        ];

        transactionRepository.GetAll().Returns(transactionRows);

        account.printStatement();

        List<StatementRow> statementRows = [
            new StatementRow(transactionRows[0], 1),
            new StatementRow(transactionRows[1], 11)
        ];
        var validation = Arg.Is<List<StatementRow>>(list => areEqual(list, statementRows));

        printer.Received().Print(validation); 

   
    }

    private bool areEqual(List<StatementRow>list1, List<StatementRow> list2){
        try{

            list1.ShouldBeEquivalentTo(list2);
            return true;

        } catch{

            return false;
        }
    }
}
