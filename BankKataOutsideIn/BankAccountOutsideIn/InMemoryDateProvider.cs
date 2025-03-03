
namespace BankAccountOutsideIn;

public class InMemoryDateProvider : DateProvider
{

    internal DateTime date;
    public DateTime GetDate()
    {
        return date;
    }

    public void SetDate(DateTime date)
    {
        this.date = date;
    }
}