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

    [TestCase("L", "0:0:W", TestName = "move from North to West")]
    [TestCase("R", "0:0:E", TestName = "move from North to East")]
    [TestCase("RR", "0:0:S", TestName = "move from North to South only turning right")]
    [TestCase("RRR", "0:0:W", TestName = "move from North to West only turning right")]
    [TestCase("RRRR", "0:0:N", TestName = "move from North to North only turning right")]
    [TestCase("LL", "0:0:S", TestName = "move from North to South only turning left")]
    [TestCase("LLL", "0:0:E", TestName = "move from North to West only turning left")]
    [TestCase("LLLL", "0:0:N", TestName = "move from North to North only turning left")]
    public void changes_orientation(string command, string expected) {

        var result = new MarsRoversSimple().Execute(command);

        result.ShouldBe(expected);
    }

    [Test]
    public void move_south_when_rovers_move_only_once_forward_and_its_direction_is_South_and_at_the_border() {
        string command = "RRM";
        string expected = "0:9:S";

        var result = new MarsRoversSimple().Execute(command);

        result.ShouldBe(expected);
    }
}
