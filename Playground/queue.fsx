type 'a Stack =
    | EmptyStack
    | StackNode of 'a * 'a Stack

module Stack =
    let hd = function
        | EmptyStack -> failwith "Empty stack"
        | StackNode(hd, tl) -> hd

    let tl = function
        | EmptyStack -> failwith "Emtpy stack"
        | StackNode(hd, tl) -> tl

    let cons hd tl = StackNode(hd, tl)

    let empty = EmptyStack

    let rec rev s =
        let rec loop acc = function
            | EmptyStack -> acc
            | StackNode(hd, tl) -> loop (StackNode(hd, acc)) tl
        loop EmptyStack s

type Queue<'T>(front : Stack<'T>, rear : Stack<'T>) =
  let chk = function
  | EmptyStack, rear -> Queue(Stack.rev rear, EmptyStack)
  | front, rear -> Queue(front, rear)

  member this.Hd =
    match front with
    | EmptyStack -> failwith "Empty Stack"
    | StackNode(hd, tl) -> hd

  member this.Tl =
    match front, rear with
    | EmptyStack, _ -> failwith "Empty Stack"
    | StackNode(hd, tl), r -> chk(front, rear)

  member this.Enqueue x = chk(front, StackNode(x, rear))

  static member empty = Queue<'T>(Stack.empty, Stack.empty)
