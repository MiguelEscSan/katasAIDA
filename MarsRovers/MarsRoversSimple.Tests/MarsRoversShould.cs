using Shouldly;

namespace MarsRoversSimple.Tests;

public class MarsRoversShould
{

    [Test]
    public void give_initial_position_when_started() {
        string command = "";
        string expected = "0:0:N";

        var result = new MarsRoversSimple().Execute(command);

        result.ShouldBe(expected);
    }
}
