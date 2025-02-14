namespace MarsRoversSimple;
public class MarsRoversSimple : MarsRovers {

    public Position currentPosition {get; set;}

    public MarsRoversSimple() {
        this.currentPosition = new Position(new Coordinates(0,0), "N");
    }


    public string Execute(string command) {
        foreach(var letter in command.Split()) {
            if(letter == "M") {
                this.currentPosition.currentCoordinates.y += 1;
            }
        }
        return this.currentPosition.ToString();
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