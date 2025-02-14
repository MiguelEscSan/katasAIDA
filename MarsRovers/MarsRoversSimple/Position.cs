namespace MarsRoversSimple;

public class Position {

    Coordinates currentCoordinates;
    string currentOrientation;

    public Position(Coordinates coordinates, string currentOrientation) {
        this.currentCoordinates = coordinates;
        this.currentOrientation = currentOrientation;
    }

    public string ToString() {
        return $"{currentCoordinates.ToString()}:{currentOrientation}";
    }

}