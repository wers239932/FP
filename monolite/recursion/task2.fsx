let rec sumDiag n = 
    if n=1L then 1L
    else sumDiag (n-2L) + n*n + (n*n - (n-1L)) + (n*n - 2L*(n-1L)) + (n*n - 3L*(n-1L))


printf $"sum = {sumDiag 1001}\n"