module Table

type Cell = { x: int64; y: int64; num: int64 }

let rec generateCells n =
    seq {
        if n > 1L then
            yield! generateCells (n - 2L)

            for i in 1L .. n - 1L do
                yield
                    { x = (n - 1L) / 2L
                      y = (n - 1L) / 2L - i
                      num = n * n - 4L * n + 4L + i }

            for i in 1L .. n - 1L do
                yield
                    { x = (n - 1L) / 2L - i
                      y = -(n - 1L) / 2L
                      num = n * n - 4L * n + 4L + n - 1L + i }

            for i in 1L .. n - 1L do
                yield
                    { x = -(n - 1L) / 2L
                      y = -(n - 1L) / 2L + i
                      num = n * n - 4L * n + 4L + (n - 1L) * 2L + i }

            for i in 1L .. n - 1L do
                yield
                    { x = -(n - 1L) / 2L + i
                      y = (n - 1L) / 2L
                      num = n * n - 4L * n + 4L + (n - 1L) * 3L + i }
        else
            yield { x = 0L; y = 0L; num = 1L }
    }

let takeGoodOnesFromCells (cells: seq<Cell>) =
    cells |> Seq.filter (fun cell -> cell.x = cell.y || cell.x = -cell.y)

let summator (a: Cell) (b: Cell) = { x = 0; y = 0; num = a.num + b.num }

let count (cells: seq<Cell>) =
    (cells |> Seq.fold summator { x = 0; y = 0; num = 0 }).num

let solveModules = generateCells >> takeGoodOnesFromCells >> count
