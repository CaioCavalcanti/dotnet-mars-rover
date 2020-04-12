# Mars Rover Challenge
Mars Rover challenge built on .NET Core 3.1 Console App

## Problem Statement
Cardano has recently created a new department to build software/middleware for remote devices in space. Cardano has developed a Mars Rover that runs on the .Net platform. This rover must navigate around a plateau of the planet Mars. Cardano headquarters on Earth will send a command to the rover in Mars indicating the dimensions of the plateau and a movement sequence the rover must follow. If more than one rover is deployed, then the Cardano command will contain more than one rover command.

Movement String 
```
M: move to next grid location
L: turn left
R: turn right 
```

Example Cardano Command
```
5 5
1 2 N
LML
```

The “5 5” part of the string that indicates the size of the plateau.  “1 2 N” indicates that the rover is positioned on grid square 1,2 and is pointing north.  So, if the rover moved, it would move in the direction it was facing, in this case north.  The last part of the command is the movement sequence.  “LML” means, ‘turn left, move, turn left’.

Additionally, the rover must not drive off the plateau. Should a human error occur, e.g. should an operator try to drive the multi-million-dollar rover off the plateau, the rover should stop and await rescue.  

There can also be two or more rovers, in which case the instructions for all rovers will be sent.  Of course, the size of the exploration plateau will be the same.  For example, the command below will instruct two rovers on the 5 by 5 plateau:
```
5 5
1 2 N
LML
3 3 E
MMR
```

Your task is to develop the software that will parse the command and move the rover(s).


## Running application
To run this app you need [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) installed.


```
$ git clone git@github.com:CaioCavalcanti/dotnet-mars-rover.git
$ cd dotnet-mars-rover\src\Cardano.MarsRover.ConsoleApp
$ dotnet restore
$ dotnet run
```

This command will run the application using a sample command available on the code. You can also pass commands from a file, using the command
```
$ dotnet run -- CommandFilePath=commandsFile.txt
```

There are some command examples available on directory `example-commands` you can use them with the same command
```
$ dotnet run -- CommandFilePath=..\..\examples-commands\one-rover-happy-flow.txt
```

## Testing
### Unit test
```
$ git clone git@github.com:CaioCavalcanti/dotnet-mars-rover.git
$ cd dotnet-mars-rover\src\Cardano.MarsRover.ConsoleApp
$ dotnet restore
$ dotnet test
```

### Integration Tests
`TODO`

## Improvement opportunities
- Resolve TODOs
- Use events and commands async 
    - Report device position and command status when ExecutedDeviceCommand
    - Show final result when receive FinishedMovementSequence from all deployed devices
    - Report error when StoppedMovementSequence
- Extract some methods to a better abstraction (IMission for example)
- Validate input command sequence
- Check if next position is available before moving forward
- Improve exception handling
- Let rovers run in parallel
    - How to avoid collision?
- Improve output
- Integration tests