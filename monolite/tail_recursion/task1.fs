module TailRecursionTask1

let solveTailRecursion n =
    let rec loop acc divisor num =
        if num = 1L then
            acc
        elif num % divisor = 0L then
            loop divisor divisor (num / divisor)
        else
            loop acc (divisor + 1L) num

    loop 1L 2L n
