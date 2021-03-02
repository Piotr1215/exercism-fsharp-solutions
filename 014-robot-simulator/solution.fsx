type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

type Robot =
    { Direction: Direction
      Position: Position }

type Command =
    | TurnRight
    | TurnLeft
    | Advance

let create direction position =
    { Direction = direction
      Position = position }


let turnRight (direction: Direction): Direction =
    match direction with
    | North -> East
    | East  -> South
    | South -> West
    | West  -> North

let turnLeft (direction: Direction): Direction =
    match direction with
    | North -> West
    | East  -> North
    | South -> East
    | West  -> South

let advance (robot: Robot) =
    let x, y = robot.Position
    let direction = robot.Direction

    match direction with
    | North -> create North (x, y + 1)
    | East -> create East (x + 1, y)
    | South -> create South (x, y - 1)
    | West -> create West (x - 1, y)

let applyToRobot (robot: Robot) (command: Command): Robot =
    match command with
    | TurnRight -> { robot with Direction = turnRight robot.Direction }
    | TurnLeft  -> { robot with Direction = turnLeft  robot.Direction }
    | Advance   -> advance robot

let translateCommands (inputChar: char): Command =
    match inputChar with
    | 'R' -> TurnRight
    | 'L' -> TurnLeft
    | 'A' -> Advance
    | _   -> invalidArg (nameof inputChar) "Invalid input character."

let move (instructions: string) (robot: Robot): Robot =
    instructions
    |> Seq.map translateCommands
    |> Seq.fold applyToRobot robot

// Run Robot
let run =
    let robot = create Direction.North (7, 3)
    let expected = create Direction.West (9, 4)
    move "RAALAL" robot
run