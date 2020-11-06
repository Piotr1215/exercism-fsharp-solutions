open System

(*Check if list is a palindrome *)
let is_palindrome list = list = List.rev list

(*Check if string is a palindrome *)
let isPalindrom (s:string) = s.ToLower() |> Seq.toList |> (fun l -> List.rev l = l)

is_palindrome ["cos";"bos";"cos1"]

isPalindrom "AbBaa"