let split list = 
    let rec aux list acc1 acc2 = 
        match list with
        | [] -> (acc1, acc2)
        | [ x ] -> (x :: acc1, acc2)
        | x :: y :: xs -> aux xs (x :: acc1) (y :: acc2)
    aux list [] []

let rec merge listA listB = 
    match (listA, listB) with
    | (x, []) -> x
    | ([], y) -> y
    | (x :: xs, y :: ys) -> 
        if x <= y then x :: merge xs listB
        else y :: merge listA ys

let rec mergesort list = 
    match list with
    | [] -> []
    | [ x ] -> [ x ]
    | _ -> 
        let (listA, listB) = split list
        merge (mergesort listA) (mergesort listB)
