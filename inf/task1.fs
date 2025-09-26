module InfTask1

let solveInf n =
    let rec loop num (candidates: seq<int64>) =
        let d = candidates |> Seq.head
        if d * d > num then num
        elif num % d = 0L then loop (num / d) candidates
        else loop num (candidates |> Seq.tail)
    loop n (Seq.initInfinite (fun i -> int64(i + 2)))

// printfn "Задача 1 (ленивый список): %d" (solveInf 600851475143L)
