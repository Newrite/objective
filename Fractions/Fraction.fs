namespace Fractions
  
[<AutoOpen>]
module private Fraction =

  let (|OverflowPlus|NoOverflow|) (decA: uint8, decB: uint8) =
    if decA > (System.Byte.MaxValue - decB)
      then
        OverflowPlus
    else NoOverflow
    
  let (|OverflowMinus|NoOverflow|) (decA: uint8, decB: uint8) =
    if decA < decB
      then
        OverflowMinus
    else NoOverflow
    
  let (|OverflowMult|NoOverflow|) (decA: int64, decB: int64) =
    let temp = decA * decB
    if temp <= 255L then NoOverflow else
      OverflowMult (temp/255L)
    

type Fraction(integer: int64, decimal: uint8) =
  
  let integer' = integer
  let decimal' = decimal
  
  do
    printfn "Create new number, ingeger: %d decimal: %d" integer decimal
  
  
  new() = Fraction(0L, 0uy)
  new(a) = Fraction(a, 0uy)
  
  member self.Integer = integer'
  member self.Decimal = decimal'
  
  override self.Equals(b) =
    match b with
    | :? Fraction as f -> (f.Decimal = self.Decimal) && (f.Integer = self.Integer)
    | _ -> false
    
  override self.GetHashCode() =
    hash (self.Integer, self.Decimal)
  
  static member (+) (a: Fraction, b: Fraction) =
    let integer'', decimal'' =
      match a.Decimal, b.Decimal with
      |OverflowPlus -> (a.Integer+b.Integer+1L), (a.Decimal+b.Decimal)
      | _ -> (a.Integer+b.Integer), (a.Decimal+b.Decimal)
    Fraction(integer'', decimal'')
    
  static member (*) (a: Fraction, b: Fraction) =
    let integer'', decimal'' =
      let temp = int64 a.Decimal, int64 b.Decimal
      match temp with
      |OverflowMult count -> ((a.Integer*b.Integer)+count), (a.Decimal*b.Decimal)
      | _ -> (a.Integer*b.Integer), (a.Decimal*b.Decimal)
    Fraction(integer'', decimal'')
    
  static member (-) (a: Fraction, b: Fraction) =
    let integer'', decimal'' =
      match a.Decimal, b.Decimal with
      |OverflowMinus -> (a.Integer-b.Integer-1L), (a.Decimal-b.Decimal)
      | _ -> (a.Integer-b.Integer), (a.Decimal-b.Decimal)
    Fraction(integer'', decimal'')