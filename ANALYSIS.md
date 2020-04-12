# Problem Analysis

## Text analysis
### Nouns
- Cardano
- Device
- Space
- Rover
- Planet 
- Mars
- Plateau
- Headquarter
- Earth
- Command
- Dimension (of a plateau)
- Movement
- Size (of a plateau)
- Direction (of a movement)
- Left 
- Right
- North
- Instruction
- Error
- Operator

### Verbs
- Navigate (a plateau)
- Send command (to a rover)
- Indicate (dimensions and movement sequence)
- Follow (a command)
- Move (a rover)
- Turn (a rover)
- Drive (a rover)
- Point (to a direction)
- Face (a direction)
- Instruct (a rover)
- Occur (an error)
- Try (to drive a rover)
- Stop (a rover)
- Await (rescue)

### Adjectives 
- Remote (device)
- Deployed (rover)
- Multi-million-dollar (rover)
- Human (error)

## Assumptions
- The command input is a string
- A position on plateau is defined by (x, y), where x and y are non-negative integers
- The lower-left of the plateau is assumed to be position (0, 0)
- North direction is represented by (x, y+1)
- The only possible directions are North (N), East (E), South (S) and West (W), as result a rover turns 90 degrees left or right and cannot move diagonally
- A command cannot have an empty movement sequence
- When multiple rovers are deployed, the commands are executed sequentially, when the first rover finishes executing a movement sequence, the next rover starts its movement sequence
- Rovers cannot occupy the same position at the same time
- When the command is finished, all rovers report the current position, direction it is pointing and movement sequence status (OK or NOK)
    - 1 2 N OK
- Rescuing a rover is out of scope