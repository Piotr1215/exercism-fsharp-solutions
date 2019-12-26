type Plant =
    | Radishes
    | Clover
    | Grass
    | Violets

let mapLetterToPlant letter =
    match letter with
    | 'V' -> Violets
    | 'R' -> Radishes
    | 'G' -> Grass
    | 'C' -> Clover
    | _ -> failwith "There is no such plant"

let getIndexOfStudentsName (student: string) =

    seq {'A'..'Z'}
    |> Seq.findIndex (fun f -> f = student.[0])

let plants (diagram: string) student =
    diagram.Split('\n')
    |> Seq.collect (Seq.skip ((getIndexOfStudentsName student) *2) >> Seq.take 2)
    |> Seq.map mapLetterToPlant
    |> Seq.toList

let student = "Alice"
let diagram = "RC\nGG"
let expected = [Plant.Radishes; Plant.Clover; Plant.Grass; Plant.Grass]
plants diagram student