namespace MarsRoversSimple;

public class Position {

    public Coordinates currentCoordinates {get; set;}
    public string currentOrientation {get; set;}

    public Position(Coordinates coordinates, string currentOrientation) {
        this.currentCoordinates = coordinates;
        this.currentOrientation = currentOrientation;
    }

    public string ToString() {
        return $"{currentCoordinates.ToString()}:{currentOrientation}";
    }

}