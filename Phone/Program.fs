open Phone

let hello (caller:ICaller) =
  caller.ReceiveCall("Keke")

[<EntryPoint>]
let main _ =
  let p = Phone(81237123, "Name", 20.0)
  hello(p)
  p.ReceiveCall("Anton", 89767123)
  p.ReceiveCall("Lexa")
  p.GetNumber() |> printfn "Number: %d"
  p.SendMessage(8912323, "aliha")
  p.SendMessage([787123; 891283; 1983; 181273; 71263], "ALHA")
  0