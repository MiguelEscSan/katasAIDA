namespace MarsRoversSimple;
public class MarsRoversSimple : MarsRovers {

    (int, int) currentCoordinates;
    string currentOrientation;
    

    public string Execute(string command) {
        var currentPosition = new Position(new Coordinates(0,0), "N");
        return currentPosition.ToString();
    }
}

public class GameBoard {

    int height;
    int width;

    public GameBoard(int height = 10, int width = 10) {
        this.height = height;
        this.width = width;
    }

}