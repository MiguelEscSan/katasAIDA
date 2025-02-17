namespace MarsRoversSimple;
public class MarsRoversSimple : MarsRovers {

    public Position currentPosition {get; set;}

    public GameBoard gameBoard{get; set;}

    public MarsRoversSimple() {
        this.currentPosition = new Position(new Coordinates(0,0), "N");
        this.gameBoard = new GameBoard();
    }


    public string Execute(string command) {

        for(int position = 0; position < command.Length; position++) {
            switch(command[position]) {
                case 'M':
                    this.MoveForward();
                    break;
                case 'L':
                case 'R':
                    this.TurnDirection(command[position].ToString());
                    break;
                default:
                    return "";
            }       
        }
        return this.currentPosition.ToString();
    }

    public void MoveForward() {

        switch(this.currentPosition.currentOrientation) {
         
            case "N":
                this.currentPosition.currentCoordinates.y = NextCoordinates( this.currentPosition.currentCoordinates.y +1 , this.gameBoard.height);
                break;
            case "S":
                this.currentPosition.currentCoordinates.y = NextCoordinates( this.currentPosition.currentCoordinates.y -1 , this.gameBoard.height);
                break;
            case "E":
                this.currentPosition.currentCoordinates.x = NextCoordinates( this.currentPosition.currentCoordinates.x +1 , this.gameBoard.width);
                break;
            case "W":
                this.currentPosition.currentCoordinates.x = NextCoordinates( this.currentPosition.currentCoordinates.x -1 , this.gameBoard.width);
                break;
            default:
                return;
        }
    }

    public  int NextCoordinates(int value, int max){
        if (value < 0) return max -1;
        if (value >= max) return 0;
        return value;
    }

    public void TurnDirection(string orientationCommand){

        List<string> orientations =["W", "N", "E","S"];
        int orientationIndex = orientations.IndexOf(this.currentPosition.currentOrientation);

        if(orientationCommand == "R" ){
            orientationIndex = (orientationIndex + 1) % orientations.Count;
        }
        if(orientationCommand == "L" ){
            orientationIndex = (orientationIndex - 1 + orientations.Count) % orientations.Count;
        }
        this.currentPosition.currentOrientation = orientations[orientationIndex];
    }
}

public class GameBoard {

    public int height {get;}
    public int width {get;}

    public GameBoard(int height = 10, int width = 10) {
        this.height = height;
        this.width = width;
    }

}