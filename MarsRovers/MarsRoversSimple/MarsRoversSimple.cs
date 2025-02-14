namespace MarsRoversSimple;
public class MarsRoversSimple : MarsRovers {

    public Position currentPosition {get; set;}

    public MarsRoversSimple() {
        this.currentPosition = new Position(new Coordinates(0,0), "N");
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

    public void MoveForward(){
        if(this.currentPosition.currentOrientation == "N") {
                this.currentPosition.currentCoordinates.y += 1;
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

// public class GameBoard {

//     int height;
//     int width;

//     public GameBoard(int height = 10, int width = 10) {
//         this.height = height;
//         this.width = width;
//     }

// }