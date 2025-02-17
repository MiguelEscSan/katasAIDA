namespace MarsRoversSimple.MarsRoversStates;
public class LookingEastMarsRoversState : MarsRoversState
{

    public Coordinates coordinates { get; set;}

    public LookingEastMarsRoversState(Coordinates coordinates) {
        this.coordinates = coordinates;
    }

    public MarsRoversState Execute(string command) {
        switch (command) {
            case "M":
                return MoveForward();
            case "L":
                return TurnLeft();
            case "R":
                return TurnRight();
            default:
                return this;
        }
    }

    public MarsRoversState TurnRight() {
        return new LookingSouthMarsRoversState(this.coordinates);
    }
    public MarsRoversState TurnLeft() {
        return new LookingNorthMarsRoversState(this.coordinates);
    }
    public MarsRoversState MoveForward() {
        this.coordinates.x = this.coordinates.NextCoordinates(this.coordinates.x + 1, 10);
        return new LookingEastMarsRoversState(this.coordinates);
    }

    public string ToString() {
        return $"{this.coordinates.ToString()}:E";
    }
}
