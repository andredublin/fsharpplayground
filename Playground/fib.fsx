open System.Collections.Generic

let rec fib n =
    if n <= 2 then n
    else fib (n - 1) + fib (n - 2)
    
// tail recursive
let tailFib n =
    let rec fibRec (n, x, y) =
        if n = 0I then x
        else fibRec ((n - 1I), y, (x + y))
    fibRec n, 0I, 1I
    
// memoization
let rec fibMem n : bigint =
    let cache = Dictionary<_,_>()
    let rec tailFib = function
        | n when n = 0I -> 0I
        | n when n = 1I -> 1I
        | n -> tailFib (n - 1I) + tailFib (n - 2I)
    if cache.ContainsKey(n) then cache.[n]
    else
        let result = fibMem n
        cache.[n] <- result
        result