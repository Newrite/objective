namespace Phone

type ISender =
  abstract SendMessage: int * string -> unit
  abstract SendMessage: int list * string -> unit