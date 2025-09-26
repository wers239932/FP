module InfTests

open NUnit.Framework
open TestHelpers

[<TestFixture>]
type InfTask1Tests() =

    [<Test>]
    member _.``solveInf should find largest prime factor of target number``() =
        assertEqualLong 6857L (InfTask1.solveInf 600851475143L)

[<TestFixture>]
type InfTask2Tests() =

    [<Test>]
    member _.``solveInf should calculate spiral sum for target size``() =
        assertEqualLong 669171001L (InfTask2.solveInf 1001)
