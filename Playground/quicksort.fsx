let rec quicksort = function
    | [] -> []
    | x::xs -> 
        let lessthan, greaterEqual = List.partition ((>) x) xs
        quicksort lessthan @ x :: quicksort greaterEqual 

let rand = new System.Random()
let data = List.init 10 (fun _ -> rand.Next())
let result = quicksort data
let result2 = List.sort data

let rec quicksortSeq n =
    seq {
        match Seq.toList n with
        | x::xs ->
            let lessthan, greaterEqual = List.partition ((>=) x) xs
            yield! quicksort lessthan
            yield! x
            yield! quicksort greaterEqual
        | _ -> ()
    }