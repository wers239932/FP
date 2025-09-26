module PrimeFactors

let isPrime n =
    if n < 2L then
        false
    else
        let bound = int64 (sqrt (float n))
        seq { 2L .. bound } |> Seq.forall (fun d -> n % d <> 0L)

let generateCandidates n = seq { 2L .. int64 (sqrt (float n)) }

let filterPrimeDivisors n =
    generateCandidates n |> Seq.filter (fun d -> n % d = 0L && isPrime d)

let solveModules n =
    filterPrimeDivisors n |> Seq.fold (fun acc d -> if d > acc then d else acc) 1L
