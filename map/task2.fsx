let spiralDiagonalSum size =
    1L +
    (seq { 3 .. 2 .. size }
     |> Seq.map (fun n -> 4L * int64 n * int64 n - 6L * int64 (n - 1))
     |> Seq.sum)

printfn "ans: %d" (spiralDiagonalSum 1001)
