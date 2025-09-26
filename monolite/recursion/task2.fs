module RecursionTask2

let rec solveRecursion n = 
    if n=1L then 1L
    else solveRecursion (n-2L) + n*n + (n*n - (n-1L)) + (n*n - 2L*(n-1L)) + (n*n - 3L*(n-1L))


// printf $"sum = {solveRecursion 1001}\n"