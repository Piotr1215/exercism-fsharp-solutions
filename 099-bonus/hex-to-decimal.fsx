open System

//let convertToHex = String.Format("{0:x}", decValue);

let hexToDec s = float(Int32.Parse(s, System.Globalization.NumberStyles.HexNumber))

(* let hexToDec' (s:string) =
    let ns = s.Remove(0,9).ToUpper()
    printfn "%s" ns
    Seq.toList ns
    |> Seq.filter (fun c -> Char.IsDigit(c) || Char.IsLetter(c))
    |> Seq.toArray
    |> String
    |> (fun x-> Convert.ToInt64(x, 16))
    |> (fun x -> float x) *)


hexToDec "hexToDec \"11\""