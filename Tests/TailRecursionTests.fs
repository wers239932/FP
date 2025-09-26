module TailRecursionTests

open NUnit.Framework
open TestHelpers

[<TestFixture>]
type TailRecursionTask1Tests() =

    [<Test>]
    member _.``solveTailRecursion should find largest prime factor of target number``() =
        assertEqualLong 6857L (TailRecursionTask1.solveTailRecursion 600851475143L)

[<TestFixture>]
type TailRecursionTask2Tests() =

    [<Test>]
    member _.``solveTailRecursion should calculate spiral sum for target size``() =
        assertEqualLong 669171001L (TailRecursionTask2.solveTailRecursion 1001L)