namespace MarsRoversSimple;

public class Coordinates {

    public int x {get; set;}
    public int y {get; set;}

    public int GridSize = 10;
    public Coordinates(int x, int y) {
        this.x = x;
        this.y = y;
    }

    // public  int NextCoordinates(int value, int max){
    //     if (value < 0) return max -1;
    //     if (value >= max) return 0;
    //     return value;
    // }
    
    public Coordinates XAxisNextCoordinates(Coordinates coordinates, int step){
        coordinates.x = (coordinates.x + step + GridSize) % GridSize;
        return coordinates;
    }

    public Coordinates YAxisNextCoordinates(Coordinates coordinates, int step){
        coordinates.y = (coordinates.y + step + GridSize) % GridSize;
        return coordinates;
    }



    public string ToString() {
        return $"{x}:{y}";
    }
}