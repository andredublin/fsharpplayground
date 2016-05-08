type Stack<'T>() = 
    let mutable _stack : List<'T> = []
    member x.Push value = lock _stack (fun () -> _stack <- value :: _stack)
    
    member x.Pop() = 
        lock _stack (fun () -> 
            match _stack with
            | x :: xs -> 
                _stack <- xs
                x
            | [] -> failwith "Stack is Empty")
    
    member x.TryPop() = 
        lock _stack (fun () -> 
            match _stack with
            | x :: xs -> 
                _stack <- xs
                x |> Some
            | [] -> None)

let stack = Stack<string>()

stack.Push("foobar")
stack.Push("fizzbuzz")
stack.Push("bizzbazz")
stack.Push("foo")
stack.Pop() // foo
stack.Pop() // bizzbazz
stack.Pop() // fizzbuzz
stack.Pop() // foobar
stack.Pop() // System.Exception: Stack is Empty
stack.TryPop() // None

let balanceExpression expr =
    let rec balance xs stack =
        match (xs, stack) with
        | [], [] -> true
        | [], _ -> false
        | '(' :: ys, stack -> balance ys ('(' :: stack)
        | ')' :: ys, '(' :: stack -> balance ys stack
        | ')' :: _, _ -> false
        | _ :: ys, stack -> balance ys stack
    balance (Seq.toList expr) []

balanceExpression "(())" // true
balanceExpression "(((()))" // false