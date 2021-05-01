namespace Person

type Person(fullName: string) =
  
  let m_fullName = fullName
  
  new() = Person("")
  
  interface IMover with
    member self.Move() =
      match m_fullName with
      |"" -> printfn "Where is you name."
      | _ -> printfn $"{m_fullName} move out."
  
  ///Print move action
  member self.Move() =
    (self :> IMover).Move()
    
  interface ITalker with
    member self.Talk() =
      match m_fullName with
      |"" -> printfn "Where is you name."
      | _ -> printfn $"{m_fullName} is talk."
      
  ///Print talk action
  member self.Talk() =
    (self :> ITalker).Talk()