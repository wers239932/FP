// Main program file
open System

[<EntryPoint>]
let main argv =
    printfn "F# Lab Project - All functions renamed successfully!"

    // Test one function from each category
    printfn "Testing CycleTask1.solveCycle: %d" (CycleTask1.solveCycle 600851475143L)
    printfn "Testing InfTask1.solveInf: %d" (InfTask1.solveInf 600851475143L)
    printfn "Testing MapTask1.solveMap: %d" (MapTask1.solveMap 600851475143L)
    printfn "Testing PrimeFactors.solveModules: %d" (PrimeFactors.solveModules 600851475143L)
    printfn "Testing RecursionTask1.solveRecursion: %d" (RecursionTask1.solveRecursion 600851475143L)
    printfn "Testing TailRecursionTask1.solveTailRecursion: %d" (TailRecursionTask1.solveTailRecursion 600851475143L)

    0
