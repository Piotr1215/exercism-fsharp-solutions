open System

type Clock =
    {
        Hours: int
        Minutes: int
    }

let create hours minutes =
    let hoursOfMinutes = minutes / 60
    let minutesRemainder = minutes % 60

    let minutesFinal, hourSubtracted =
        if minutesRemainder < 0
        then (minutesRemainder + 60, 1)
        else (minutesRemainder, 0)

    let hoursTotal = (hours + hoursOfMinutes - hourSubtracted) % 24
    let hoursFinal =
        if hoursTotal < 0
        then hoursTotal + 24
        else hoursTotal

    { Hours = hoursFinal; Minutes = minutesFinal }

let add minutes clock = create clock.Hours (clock.Minutes + minutes)

let subtract minutes clock = add -minutes clock

let display clock =  sprintf "%02i:%02i" clock.Hours clock.Minutes

let clock = create 8 0

display clock