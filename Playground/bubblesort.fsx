let swap x y (arr : 'c []) =
    let temp = arr.[x]
    arr.[x] <- arr.[y]
    arr.[y] <- temp
    
let bubblesortA array =
    let rec loop (array : 'c []) =
        let mutable swaps = 0
        for i = 0 to array.Length - 2 do
            if array.[i] > array.[i + 1] then
                swap i (i + 1) array
                swaps <- swaps + 1
        if swaps > 0 then loop array
        else array
    loop array
    
let arr = [|5; 4; 8; 20; 1|]
bubblesortA arr

let rec getHighest list =
    match list with
    | x :: y :: xs when x > y -> x :: xs |> getHighest
    | x :: y :: xs -> y :: xs |> getHighest
    | x :: [] -> x
    | _ -> failwith "Unrecoginzed pattern"
        
let bubblesortB list =
    let rec innersort sorted = function
    | [] -> sorted
    | l ->
        let h = getHighest l
        let (x, y) = List.partition (fun i -> i = h) l
        innersort (x @ sorted) y
    innersort [] list
    
let data = [1683249965; 135774752; 1627998559; 1112950566; 373482178; 1031234918; 505894459; 306487619; 1126406242; 1370137881]
bubblesortB data