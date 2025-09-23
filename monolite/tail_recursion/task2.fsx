let sumDiag n =
    let rec sumUpTo n sum = 
        if n = 1L then sum+1L
        else sumUpTo (n-2L) (sum+n*n + (n*n - (n-1L)) + (n*n - 2L*(n-1L)) + (n*n - 3L*(n-1L)))
        
    sumUpTo n 0L

printf $"sum = {sumDiag 1001}\n"