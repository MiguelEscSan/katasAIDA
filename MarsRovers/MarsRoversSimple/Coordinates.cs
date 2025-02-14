namespace MarsRoversSimple;

public class Coordinates {

    int x;
    int y;
    public Coordinates(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public string ToString() {
        return $"{x}:{y}";
    }
}