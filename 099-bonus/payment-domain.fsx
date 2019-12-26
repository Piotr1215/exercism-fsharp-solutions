// Type declarations for payment domain
type CheckNumber = int
type CardNumber = string
type CardType = Visa | MasterCard
type CreditInfo = CardType * CardNumber

type PaymentMethod =
    | Cash
    | Check of CheckNumber
    | Card of CreditInfo

type PaymentAmount = decimal
type Currency = EUR | USD

type Payment = {
    Amount : PaymentAmount
    Currency : Currency
    Method : PaymentMethod
}

let checkPayment = {Amount = 0.7833M ; Currency = EUR; Method = (Check  2)}
let bigCashPayment = {Amount = 122.7833M ; Currency = USD; Method = Cash}
let creditCardPayment = {Amount = 121.7833M ; Currency = EUR; Method = Card (Visa, "442342344234234")}

let transactionsList = [checkPayment; bigCashPayment; creditCardPayment]

let cashPrint payment =
    printfn "Payment done with %A for amount %f" payment.Method payment.Amount

let sumPayments payments =
    let paymentsSum = payments |> List.sumBy (fun a -> a.Amount)
    printfn "Transactions sum %A" paymentsSum

sumPayments transactionsList