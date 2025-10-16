module ImmutableHashMapTests

open Xunit
open ImmutableHashMap

[<Fact>]
let ``add and tryFind should return inserted value`` () =
    let map =
        empty
        |> add 1 "one"
        |> add 2 "two"

    Assert.Equal(Some "one", tryFind 1 map)
    Assert.Equal(Some "two", tryFind 2 map)

[<Fact>]
let ``remove should delete key`` () =
    let map =
        empty
        |> add 1 "a"
        |> add 2 "b"
        |> remove 1

    Assert.Equal(None, tryFind 1 map)
    Assert.Equal(Some "b", tryFind 2 map)

[<Fact>]
let ``containsKey should detect presence and absence`` () =
    let map =
        empty
        |> add 1 "a"
        |> add 2 "b"

    Assert.True(map |> containsKey 1)
    Assert.False(map |> containsKey 3)

[<Fact>]
let ``filter should remove elements not matching predicate`` () =
    let map =
        empty
        |> add 1 "one"
        |> add 2 "two"
        |> filter (fun k _ -> k % 2 = 0)

    Assert.Equal(None, tryFind 1 map)
    Assert.Equal(Some "two", tryFind 2 map)

[<Fact>]
let ``mapValues should transform all values`` () =
    let map =
        empty
        |> add 1 "a"
        |> add 2 "b"
        |> mapValues (fun s -> s.ToUpper())

    Assert.Equal(Some "A", tryFind 1 map)
    Assert.Equal(Some "B", tryFind 2 map)

[<Fact>]
let ``fold should accumulate sum of keys`` () =
    let map =
        empty
        |> add 1 "a"
        |> add 2 "b"
        |> add 3 "c"

    let result =
        map |> fold (fun acc k _ -> acc + k) 0

    Assert.Equal(6, result)

[<Fact>]
let ``combine should merge two maps and override duplicates`` () =
    let m1 =
        empty
        |> add 1 "one"
        |> add 2 "two"

    let m2 =
        empty
        |> add 2 "TWO"
        |> add 3 "three"

    let result = m1 |> combine m2

    Assert.Equal(Some "one", tryFind 1 result)
    Assert.Equal(Some "TWO", tryFind 2 result) // из m2
    Assert.Equal(Some "three", tryFind 3 result)

[<Fact>]
let ``equals should compare two identical maps as true`` () =
    let m1 =
        empty
        |> add 2 "two"
        |> add 1 "one"

    let m2 =
        empty
        |> add 1 "one"
        |> add 2 "two"

    Assert.True(m1 |> equals m2)

[<Fact>]
let ``equals should detect difference in values`` () =
    let m1 =
        empty
        |> add 1 "one"
        |> add 2 "two"

    let m2 =
        empty
        |> add 1 "one"
        |> add 2 "TWO"

    Assert.False(m1 |> equals m2)

[<Fact>]
let ``emptyMonoid and combine should follow monoid identity`` () =
    let emptyMonoid = empty<int, string>
    let m =
        empty
        |> add 1 "a"
        |> add 2 "b"

    Assert.True((m |> combine emptyMonoid) |> equals m)
    Assert.True((emptyMonoid |> combine m) |> equals m)
