// iterative
let factorialIterative x =
    let mutable n = x
    let mutable returnVal = 1
    while n >= 1 do
        returnVal <- returnVal * n
        n <- n - 1
    returnVal
    
// recursive
let rec factorialRec n =
    if n < 1 then n
    else n * factorialRec n - 1
    
let rec factorialRecPattern n =
    match n with
    | 0 | 1 -> 1
    | _ -> n * factorialRecPattern n - 1
    
// tail recursive
let factorialTail n =
    let rec tailFactorial n accum =
        if n <= 1 then accum
        else tailFactorial (n - 1) (accum * n)
    tailFactorial n 1
    
// continuation
let factorialCont n =
    let rec tailFactorial n f = 
        if n <= 1 then f()
        else tailFactorial (n - 1) (fun _ -> n * f())
    tailFactorial n (fun _ -> n - 1)
    
// fold
let factorialFold n = [1..n] |> List.fold (*) 1

// reduce
let factorialReduce n = [1..n] |> List.reduce (*)