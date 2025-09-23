open System

let factors n =
    Seq.unfold (fun (n, d) ->
        if n = 1L then None
        elif n % d = 0L then Some(d, (n / d, d))
        elif d * d > n then Some(n, (1L, n))
        else Some(0L, (n, d + 1L))
    ) (n, 2L)
    |> Seq.filter ((<>) 0L)
    |> Seq.map id

let largestPrimeFactor n =
    factors n |> Seq.max

printfn "ans: %d" (largestPrimeFactor 600851475143L)
