module MapTests

open NUnit.Framework
open TestHelpers

[<TestFixture>]
type MapTask1Tests() =
    
    [<Test>]
    member _.``solveMap should find largest prime factor of target number``() =
        assertEqualLong 6857L (MapTask1.solveMap 600851475143L)

[<TestFixture>]
type MapTask2Tests() =

    [<Test>]
    member _.``solveMap should calculate spiral sum for target size``() =
        assertEqualLong 669171001L (MapTask2.solveMap 1001)