module ModulesTests

open NUnit.Framework
open TestHelpers

[<TestFixture>]
type ModulesTask1Tests() =

    [<Test>]
    member _.``PrimeFactors.solveModules should find largest prime factor of target number``() =
        assertEqualLong 6857L (PrimeFactors.solveModules 600851475143L)

[<TestFixture>]
type ModulesTask2Tests() =

    [<Test>]
    member _.``Table.solveModules should calculate spiral sum for target size``() =
        assertEqualLong 692101L (Table.solveModules 101L)