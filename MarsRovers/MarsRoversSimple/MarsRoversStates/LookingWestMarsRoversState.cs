namespace MarsRoversSimple.MarsRoversStates;
public class LookingWestMarsRoversState : MarsRoversState
{

    public Coordinates coordinates { get; set;}

    public LookingWestMarsRoversState(Coordinates coordinates) {
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
        return new LookingNorthMarsRoversState(this.coordinates);
    }
    public MarsRoversState TurnLeft() {
        return new LookingSouthMarsRoversState(this.coordinates);
    }
    public MarsRoversState MoveForward() {
        this.coordinates.x = this.coordinates.NextCoordinates(this.coordinates.x - 1, 10);
        return new LookingWestMarsRoversState(this.coordinates);
    }

    public string ToString() {
        return $"{this.coordinates.ToString()}:W";
    }
}
