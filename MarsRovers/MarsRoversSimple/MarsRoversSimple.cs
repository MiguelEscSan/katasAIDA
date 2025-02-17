using MarsRoversSimple.MarsRoversStates;

namespace MarsRoversSimple;

public class MarsRoversSimple : MarsRovers {

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

}