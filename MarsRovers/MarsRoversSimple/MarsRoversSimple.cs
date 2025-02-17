using MarsRoversSimple.MarsRoversStates;

namespace MarsRoversSimple;

public class MarsRoversSimple : MarsRovers {

    public Position currentPosition {get; set;}

    public GameBoard gameBoard{get; set;}

    public MarsRoversState MarsRoversState;

    public MarsRoversSimple() {
        this.MarsRoversState = new LookingNorthMarsRoversState(new Coordinates(0,0));
    }


    public string Execute(string command) {

        for(int position = 0; position < command.Length; position++) {
            this.MarsRoversState = this.MarsRoversState.Execute(command[position].ToString());
        }
        return this.MarsRoversState.ToString();
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
}
    

public class GameBoard {

    public int height {get;}
    public int width {get;}

    public GameBoard(int height = 10, int width = 10) {
        this.height = height;
        this.width = width;
    }

}