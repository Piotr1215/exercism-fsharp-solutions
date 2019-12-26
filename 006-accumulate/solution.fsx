(*Learning points:
- In F# you can turn operators into functions by surrounding them with ()
  this is not possible with cons operator ::

- Using function keyword is equivalent to using match ... with
  but more succinct, beause parameter of the matching expression can
  be ommited for brevity

- Great explanation of what is cons (::) and how is works can be found
  in this thread: https://stackoverflow.com/a/2846640. Cons is a DU which takes
  generic list is either empty list or a tuple representing first element
  and rest of the list
*)

// Most succinct solution with "function" instead of match..with
// using function enables to ommit the parameter that we match on
// beacuse the parameter is evaulated in the match cases anyway
// the drawback of this is that because second parameter is not
// explicitly mentioned it negativelly affects readability
let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    let rec filterUtil acc = function
       | [] -> List.rev acc
       | x::xs -> filterUtil (func x::acc) xs
    filterUtil [] input

// This is correct solution with match ... with
let accumulate' (func: 'a -> 'b) (input: 'a list): 'b list =

    let rec filterUtil acc l =
        match l with
        | [] -> List.rev acc
        | x::xs -> filterUtil (func x::acc) xs

    filterUtil [] input

// This is initially approved solution using list comprehension
let accumulate'' (func: 'a -> 'b) (input: 'a list): 'b list =
    [for i in input -> func i]

accumulate (fun (x:string) -> x.ToUpper()) ["hello"; "world"]