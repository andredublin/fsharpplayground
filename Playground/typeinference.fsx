// compiler infers that x is an integer
let x = 42

// compiler infers that truth is a boolean
let truth = true

// compiler infers that n is an int and isTruth returns a bool
let isTruth n =
    if n > 42 then true
    else false
    
// compiler infers that the function accepts and returns int
let add a b = a + b

// the signature of add changes to float b/c the compiler infers from the first use of add
let result = add 2.0 4.0

// sum becomes statically resolved
// params are preceeded with ^ indicating that the type is replaced with the actual type at compile time instead of runtime
// the requires member or when clause specifies constraints indicating that the type must provide certain methods
// in this case (+)
let inline sum x y = x + y

// compare takes two arguments of the same type and returns a value of that same type and it must support comparison
let compare x y = 
    if x < y then -1
    elif x > y then 1
    else 0

List.sortBy (fun x -> x.Length) ["three"; "two"; "one"] // produces an error
["three"; "two"; "one"] |> List.sortBy (fun x -> x.Length)
