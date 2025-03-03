namespace BankAccountOutsideIn;

public interface DateProvider {

    DateTime GetDate();
    void SetDate(DateTime date);
}