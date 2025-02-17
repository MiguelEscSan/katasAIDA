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

    public void TurnRight(){
          Dictionary<string, string> orientations = new Dictionary<string, string>()
        {
            {"N", "E"},
            {"E", "S"},
            {"S","W"},
            {"W", "N"}
        };

        this.currentOrientation = orientations[this.currentOrientation];
    }
    public void TurnLeft(){
          Dictionary<string, string> orientations = new Dictionary<string, string>()
        {
            {"N", "W"},
            {"E", "N"},
            {"S","E"},
            {"W", "S"}
        };

        this.currentOrientation = orientations[this.currentOrientation];
    }

    
}