namespace BankAccount;

public interface Printer{
    public void Print(List<(Transaction,int)> StatementInformation);
}