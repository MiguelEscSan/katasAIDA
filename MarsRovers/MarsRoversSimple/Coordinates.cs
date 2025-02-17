namespace MarsRoversSimple;

public class Coordinates {

    public int x {get; set;}
    public int y {get; set;}
    public Coordinates(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public  int NextCoordinates(int value, int max){
        if (value < 0) return max -1;
        if (value >= max) return 0;
        return value;
    }

    public string ToString() {
        return $"{x}:{y}";
    }
}