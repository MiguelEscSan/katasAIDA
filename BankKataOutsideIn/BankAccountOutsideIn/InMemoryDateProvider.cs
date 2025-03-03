
namespace BankAccountOutsideIn;

public class InMemoryDateProvider : DateProvider
{

     internal DateTime date;
    public DateTime GetDate()
    {
        throw new NotImplementedException();
    }

    public void SetDate(DateTime date)
    {
        this.date = date;
    }
}