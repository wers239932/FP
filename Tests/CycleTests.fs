module CycleTests

open NUnit.Framework
open TestHelpers

[<TestFixture>]
type CycleTask1Tests() =
    
    [<Test>]
    member _.``solveCycle should find largest prime factor of target number``() =
        assertEqualLong 6857L (CycleTask1.solveCycle 600851475143L)

[<TestFixture>]
type CycleTask2Tests() =

    [<Test>]
    member _.``solveCycle should calculate spiral sum for target size``() =
        assertEqualLong 669171001L (CycleTask2.solveCycle 1001)