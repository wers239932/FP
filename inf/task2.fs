module InfTask2

let solveInf size =
    seq { 3..2..size }
    |> Seq.map (fun n -> 4L * int64 n * int64 n - 6L * int64 (n - 1))
    |> Seq.sum
    |> fun s -> s + 1L
