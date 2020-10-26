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


bmiActivePattern 34 23