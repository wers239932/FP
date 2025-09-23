let largestPrimeFactor  n = 
    let rec largestPrimeFactorFrom m i = 
        if i*i > m then m
        else
            if m%i=0L
                then max (largestPrimeFactorFrom (m/i) i) i
                else largestPrimeFactorFrom m (i+1L)
    
    largestPrimeFactorFrom n 2L