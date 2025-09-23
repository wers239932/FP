let spiralDiagonalSum size =
    seq {3 .. 2 .. size} // ленивый список нечётных чисел
    |> Seq.map (fun n -> 4L * int64 n * int64 n - 6L * int64 (n - 1))
    |> Seq.sum
    |> fun s -> s + 1L

printfn "Задача 2 (ленивый список): %d" (spiralDiagonalSum 1001)
