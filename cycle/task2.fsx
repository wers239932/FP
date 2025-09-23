let spiralDiagonalSum size =
    let mutable n = 3
    let mutable sum = 1L
    while n <= size do
        sum <- sum + (4L * int64 n * int64 n - 6L * int64 (n - 1))
        n <- n + 2
    sum

printfn "ans: %d" (spiralDiagonalSum 1001)
