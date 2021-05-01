open Fractions

[<EntryPoint>]
let main _ =
  let fac = Fraction(20L, 20uy)
  let bac = Fraction(20L, 250uy)
  ignore <| fac + bac
  ignore <| fac - bac
  ignore <| fac * bac
  ignore <| bac + fac
  ignore <| bac - fac
  ignore <| bac * fac
  ignore <| bac.Equals(fac)
  ignore <| fac.Equals(fac)
  0