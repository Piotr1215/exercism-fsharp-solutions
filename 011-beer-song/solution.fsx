let oneOrTwo number =
    match number with
    | 1 -> "1 bottle"
    | _ -> string number + " bottles"

let noBeer         = ["No more bottles of beer on the wall, no more bottles of beer.";
                      "Go to the store and buy some more, 99 bottles of beer on the wall."]
let oneBeer        = ["1 bottle of beer on the wall, 1 bottle of beer.";
                      "Take it down and pass it around, no more bottles of beer on the wall."]
let manyBeers beer = [sprintf "%s of beer on the wall, %s of beer." (oneOrTwo beer) (oneOrTwo beer);
                      sprintf "Take one down and pass it around, %s of beer on the wall." (oneOrTwo (beer-1))]

let rec createSong beer =
        match beer with
        | 0 -> noBeer
        | 1 -> oneBeer
        | n -> manyBeers n

let recite (startBottles: int) (takeDown: int) =
    let lastBottle = startBottles-takeDown+1
    [ startBottles .. -1 .. lastBottle ]
    |> List.map createSong
    |> List.reduce (fun acc elem -> acc @ [""] @ elem)

let expected = [ "3 bottles of beer on the wall, 3 bottles of beer.";
                 "Take one down and pass it around, 2 bottles of beer on the wall." ]
recite 3 1