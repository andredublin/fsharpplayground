// f start
// x aux
// t target 
// n moves
let rec hanoiA f x t n =
    if n > 0 then
        hanoiA f t x (n - 1)
        printfn "Move disc from %c to %c" f t
        hanoiA x f t (n - 1)

let rec hanoiB n s f =
    match n with
    | 0 -> []
    | _ -> 
        let t = (6 - s - f)
        hanoiB (n - 1) s t @ [s, f] @ hanoiB (n - 1) t f
        
hanoiB 2 1 2 |> List.iter (fun (x,y) -> printf "Move the disc from %A to %A\n" x y)