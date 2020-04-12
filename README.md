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

There are some command examples available on directory `command-examples` you can use them with the same command
```
$ dotnet run -- CommandFilePath=..\..\command-examples\one-rover-happy-flow.txt
```

## Testing
### Unit test
```
$ git clone git@github.com:CaioCavalcanti/dotnet-mars-rover.git
$ cd dotnet-mars-rover
$ dotnet restore
$ dotnet test
```

### Integration Tests
`TODO`

## Assumptions
- The command input is a string
- A position on plateau is defined by (x, y), where x and y are non-negative integers
- The lower-left of the plateau is assumed to be position (0, 0)
- North direction is represented by (x, y+1)
- The only possible directions are North (N), East (E), South (S) and West (W), as result a rover turns 90 degrees left or right and cannot move diagonally
- A command cannot have an empty movement sequence
- When multiple rovers are deployed, the commands are executed sequentially, when the first rover finishes executing a movement sequence, the next rover starts its movement sequence
- Rovers cannot occupy the same position at the same time
- When all the commands are finished, a report will show the final position (i.e. "1 2"), followed by the pointing direction ("N") and number of pending movements ("(0)") for each rover, as below:
    - 1 2 N (0)
- A rover with pending movements means that it stopped and is awaiting rescue
    - For example, given command (run `$ dotnet run -- CommandFilePath=..\..\command-examples\one-rover-exceding-plateau.txt`)
        - 2 2
        - 1 1 S
        - MMMLLMMRM
    - Expect rover output:
        - [Rover 1] 1 0 S (7)
- Rescuing a rover is out of scope
- There is no persistence layer
- When a command is sent to deploy multiple rovers, they are deployed in sequence, when the first rover finishes executing the movement sequence, the next rover is deployed

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
- Limit number of commands, since it's all in memory, it can be exploited
- Add one more mission example to validate abstraction level and extensibility 