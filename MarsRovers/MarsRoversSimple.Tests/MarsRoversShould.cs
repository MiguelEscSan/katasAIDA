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

    [Test]
    public void give_next_position_when_rovers_move_only_once_forward() {
        string command = "M";
        string expected = "0:1:N";

        var result = new MarsRoversSimple().Execute(command);

        result.ShouldBe(expected);
    }

    [Test]
    public void give_current_position_when_rovers_changes_orientation(){
        string command = "L";
        string expected = "0:0:W";

        var result = new MarsRoversSimple().Execute(command);

        result.ShouldBe(expected);
    }
}
