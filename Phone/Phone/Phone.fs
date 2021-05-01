namespace Phone

///Create phone class instance
type Phone(number, model, weight) =
  let m_number : int = number
  let m_model : string = model
  let m_weight : float = weight
  
  ///Create new phone instance with Number = 0, Model =  "", Weight = 0.0 parameters
  new() = Phone(0, "", 0.0)
  ///Create new phone instance with default weight 0.0
  new(number: int, model: string) = Phone(number, model, 0.0)
  
  interface ICaller with
    member self.ReceiveCall(callerName: string) = printfn "Звонит %s" callerName
    
  ///Print caller name in console
  member self.ReceiveCall(callerName: string) =
    (self :> ICaller).ReceiveCall(callerName)
  
  ///Print caller name and number in console
  member self.ReceiveCall(callerName: string, callerNumber: int) =
    printfn "Звонит %s с номером %d" callerName callerNumber
    
  interface ISender with
    member self.SendMessage(phoneNumber: int, message: string) =
      printfn "Phone number to send %d, message %s" phoneNumber message
    member self.SendMessage(phoneNumbers: int list, message: string) =
      printf "Message to send %s, numbers: " message
      phoneNumbers
      |>List.iter (fun number -> printf "%d " number)
      
  ///Print message for send and phone number where to it send
  member self.SendMessage(phoneNumber: int, message: string) =
    (self :> ISender).SendMessage(phoneNumber, message)
  ///Print message for send and phone numbers where to it send
  member self.SendMessage(phoneNumbers: int list, message: string) =
    (self :> ISender).SendMessage(phoneNumbers, message)
  
  ///Return phone number
  member self.GetNumber() = m_number