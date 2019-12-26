let twoFer (input: string option): string =
    let optionValue = Option.defaultValue "you" input
    "One for " + optionValue + ", one for me."

twoFer None

twoFer (Some "John")