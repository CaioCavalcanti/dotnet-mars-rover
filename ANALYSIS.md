# Text analysis
Initial text analysis to help identify possible classes, methods and abstractions.

## Nouns
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

## Verbs
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

## Adjectives 
- Remote (device)
- Deployed (rover)
- Multi-million-dollar (rover)
- Human (error)

# Questions asked

- **Q**: What is the expected output when the command is executed successfully? What is the expected output otherwise (i.e. hover stopped and is awaiting rescue)?
    - **A**: I think people who are responsible monitoring the rovers will need to know how they are doing and their whereabouts. So as long as these people can understand what’s going on, it should suffice.

- **Q**: Can a command contain an empty movement sequence?
    - Plateau: "5 5"
    - Position: "1 2 N"
    - Movement: ""
    - **A**: Let’s say NASA is sending these rovers to Mars. It is a very costly operation. So I think they’ll want to send commands for the rovers so that they can do their job on Mars (e.g. collect samples, do analysis). However it may be that the commands can be corrupted on the way from Earth to Mars so that Movement part of it can be lost. In those cases I think it is a possible scenario.

- **Q**: When multiple rovers are deployed, are the commands executed sequentially or in parallel?
    - **A**: I guess it depends how the communication will be built. What do you think are the main differences in these two options? Tradeoffs, benefits, disadvantages… ?

- **Q**: Can a rover communicate with the operator? To report status of command execution or request rescue, for example.
    - **A**: I don’t see why not. What I suppose is that people responsible for these rovers will want to know about their whereabouts and how they are doing.

- **Q**: Can a rover communicate with other rovers?
    - **A**: It depends on what added value it will bring. What do you think this rover-to-rover communication will bring to the table?

- **Q**: What can an operator do to rescue a rover?
    - **A**: I do hope it will be somewhere in the near future that humans fill set foot on Mars, but we are not there yet. So I don’t think operators will put on a suit and rescue rovers 😊 What scenarios can you think of so that Rovers need a rescue? And what do you think can be done in these cases?

- **Q**: Can an operator send a new command to a deployed rover(s)?
    - **Q1**: How can an operator send a new command to drive a single rover when there is multiple rovers deployed?
        - **A**: Do you think this will be a use case and why? If you think this will be a use case, can you think of a way how this can be achieved?
   - **Q2**: Can the subsequent commands be sent for a different number of rovers than the previous commands?
        - **A**: I think once a batch of rovers are deployed on Mars, the next batch will arrive maybe years later. So it might not be realistic to think of number of rovers will change.
    - **Q3**: Can the plateau size change on the new commands? Does it need to be always sent on a command?
        - **A**: That’s a very good question. No matter how much we analyze mars plateaus on Earth and send commands accordingly, reality may differ. Rovers, when they make it on Mars, can come across different situations, not-so-perfect plateaus. So in these cases, do you think it operators should send a new plateau or can you think of something else?