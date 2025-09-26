module RecursionTests

open NUnit.Framework
open TestHelpers

[<TestFixture>]
type RecursionTask1Tests() =

    [<Test>]
    member _.``solveRecursion should find largest prime factor of target number``() =
        assertEqualLong 6857L (RecursionTask1.solveRecursion 600851475143L)

[<TestFixture>]
type RecursionTask2Tests() =

    [<Test>]
    member _.``solveRecursion should calculate spiral sum for target size``() =
        assertEqualLong 669171001L (RecursionTask2.solveRecursion 1001L)
