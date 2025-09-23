let largestPrimeFactor (n: int64) =
    let mutable num = n
    let mutable factor = 2L
    let mutable last = 1L
    while factor * factor <= num do
        if num % factor = 0L then
            last <- factor
            num <- num / factor
        else
            factor <- factor + 1L
    if num > 1L then num else last

printfn "ans: %d" (largestPrimeFactor 600851475143L)
