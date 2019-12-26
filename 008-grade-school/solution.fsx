type Student = string
type Grade = int

type School = Map<Grade, Student list>

let empty: School = Map.empty

let add (student: Student) (grade: Grade) (school: School): School =
    let students =
        school
        |> Map.tryFind grade
        |> Option.defaultValue []
    school |> Map.add grade (student::students)

let roster (school: School): string list =
    school
    |> Map.toList
    |> List.sort
    |> List.collect (snd >> List.sort)

let grade (grade: Grade) (school: School): string list =
    school
    |> Map.tryFind grade
    |> Option.defaultValue []
    |> List.sort

let studentsToSchool (students: List<string*int>):School =
    let schoolFolder school (name,grade) =
        add name grade school
    List.fold schoolFolder empty students

let school = studentsToSchool [("Chelsea", 3); ("Logan", 7)]
roster school