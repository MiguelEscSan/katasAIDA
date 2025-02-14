namespace MarsRoversSimple;
public class MarsRoversSimple : MarsRovers {

    public Position currentPosition {get; set;}

    public MarsRoversSimple() {
        this.currentPosition = new Position(new Coordinates(0,0), "N");
    }


    public string Execute(string command) {
        foreach(var letter in command.Split()) {
    

            if(letter == "M"){
                this.MoveForward();
            }

            // if(letter == "L" && this.currentPosition.currentOrientation == "N"){
            //     this.currentPosition.currentOrientation = "W";

            // }

            if(letter == "L"){
                this.TurnDirection();
            }
        }
        return this.currentPosition.ToString();
    }

    public void MoveForward(){
        if(this.currentPosition.currentOrientation == "N") {
                this.currentPosition.currentCoordinates.y += 1;
        }
    }

    public void TurnDirection(){
        if(this.currentPosition.currentOrientation == "N"){
            this.currentPosition.currentOrientation = "W";
        }
    }
}

// public class GameBoard {

//     int height;
//     int width;

//     public GameBoard(int height = 10, int width = 10) {
//         this.height = height;
//         this.width = width;
//     }

// }