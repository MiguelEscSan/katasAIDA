namespace MarsRoversSimple.MarsRoversStates;
public class LookingSouthMarsRoversState : MarsRoversState
{

    public Coordinates coordinates { get; set;}

    public LookingSouthMarsRoversState(Coordinates coordinates) {
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
        return new LookingWestMarsRoversState(this.coordinates);
    }
    public MarsRoversState TurnLeft() {
        return new LookingEastMarsRoversState(this.coordinates);
    }
    public MarsRoversState MoveForward() {
        this.coordinates = this.coordinates.YAxisNextCoordinates(this.coordinates, -1);
        return new LookingSouthMarsRoversState(this.coordinates);
    }

    public string ToString() {
        return $"{this.coordinates.ToString()}:S";
    }
}
