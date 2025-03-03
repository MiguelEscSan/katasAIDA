using Shouldly;
using NSubstitute;

namespace BankAccountOutsideIn.Test;

public class InMemoryDateProviderShould {

    InMemoryDateProvider dateProvider;

    [SetUp]
    public void SetUp() {
        dateProvider = new InMemoryDateProvider();
    }

    [Test]

    public void set_a_date(){
        var date =  new DateTime(2030,1,1);

        dateProvider.SetDate(date);

        dateProvider.date.ShouldBe(date);
    }
}