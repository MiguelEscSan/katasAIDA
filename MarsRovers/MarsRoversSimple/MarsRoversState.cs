namespace MarsRoversSimple;
public interface MarsRoversState
{

    public Coordinates coordinates {get; set; }
    public MarsRoversState Execute(string command);

    public MarsRoversState TurnRight();
    public MarsRoversState TurnLeft();
    public MarsRoversState MoveForward();

    public string ToString();
}
