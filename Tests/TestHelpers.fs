module TestHelpers

open NUnit.Framework

let assertEqualLong expected actual =
    Assert.AreEqual(expected, actual)

let assertEqualInt expected actual =
    Assert.AreEqual(expected, actual)