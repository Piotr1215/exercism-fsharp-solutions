open System
let bmi weight height =
    let formula = float weight / float height ** 2.0
    match formula with
    | bmi when bmi <= 18.5 -> "Underweight"
    | bmi when bmi <= 25.0 -> "Normal"
    | bmi when bmi <= 30.0 -> "Overweight"
    | bmi when bmi > 30.0 -> "Obese"
    | _ -> "Unknown"

let (|LessThan|_|) k value = if value <= k then Some() else None
let (|MoreThan|_|) k value = if value >= k then Some() else None

let calculateBMI weight height = float weight / float height ** 2.0

let bmiActivePattern wieght height =
    let bmi = calculateBMI wieght height
    match bmi with
    | LessThan 18.5 -> "Underweight"
    | MoreThan 18.5 & LessThan 25.00 -> "Normal"
    | MoreThan 25.00 & LessThan 30.0 -> "Overweight"
    | MoreThan 30.00 -> "Obese"
    | _ -> "Out of scale"


let peopleWithAgeDrink old =
    match old with
    | LessThan 14 -> "drink toddy"
    | MoreThan 14 & LessThan 18 -> "drink coke"
    | MoreThan 18 & LessThan 21 -> "drink beer"
    | MoreThan 21 -> "drink whisky"
    | _ -> "Wrong age"

peopleWithAgeDrink 19