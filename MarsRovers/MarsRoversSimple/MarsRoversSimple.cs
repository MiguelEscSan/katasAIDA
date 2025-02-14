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
            if(command[position] == 'M'){
                this.MoveForward();
            }

            if(command[position] == 'L' || command[position] == 'R'){
                this.TurnDirection(command[position].ToString());
            }          
        }
        return this.currentPosition.ToString();
    }

    public void MoveForward() {

        switch(this.currentPosition.currentOrientation) {
            case "N":
                if ((this.gameBoard.height -1) >= this.currentPosition.currentCoordinates.y) this.currentPosition.currentCoordinates.y++;
                else this.currentPosition.currentCoordinates.y = 0;
                break;
            case "S":
                if (this.currentPosition.currentCoordinates.y == 0) this.currentPosition.currentCoordinates.y = this.gameBoard.height - 1;
                else this.currentPosition.currentCoordinates.y--;
                break;
            case "E":
                if ((this.gameBoard.width -1) >= this.currentPosition.currentCoordinates.x) this.currentPosition.currentCoordinates.x++;
                else this.currentPosition.currentCoordinates.x = 0;
                break;
            case "W":
                this.currentPosition.currentCoordinates.x -= 1;
                break;
            default:
                return;


        }
    }

    public void TurnDirection(string orientationCommand){

        List<string> orientations =["W", "N", "E","S"];
        int orientationIndex = orientations.IndexOf(this.currentPosition.currentOrientation);

        if(orientationCommand == "R" ){
            if(orientationIndex >= orientations.Count -1){
                this.currentPosition.currentOrientation = "W";
            } else {
                orientationIndex++ ;
                this.currentPosition.currentOrientation = orientations[orientationIndex];
            }
        }
        if(orientationCommand == "L" ){
            if(orientationIndex == 0){
                this.currentPosition.currentOrientation = "S";
            } else {
                orientationIndex--;
                this.currentPosition.currentOrientation = orientations[orientationIndex];
            }
        }


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