module ImmutableHashMap

/// узел цепочки для хранения пар (ключ, значение)
type Chain<'K, 'V> = ('K * 'V) list

/// хеш-таблица с разделением цепочек
type HashMap<'K, 'V when 'K : equality> =
    private { buckets: Chain<'K, 'V> list; capacity: int }

/// создание пустой хеш-мапы
let empty<'K, 'V when 'K : equality> : HashMap<'K, 'V> =
    { buckets = List.replicate 16 []; capacity = 16 }

/// вычисление индекса бакета по ключу
let private bucketIndex (capacity: int) (key: 'K) =
    (hash key) % capacity |> abs

/// Добавление пары (ключ, значение) в карту
/// Если ключ уже есть, значение заменяется
let add (key: 'K) (value: 'V) (map: HashMap<'K, 'V>) : HashMap<'K, 'V> =
    let idx = bucketIndex map.capacity key
    let bucket = List.item idx map.buckets
    let updatedBucket =
        bucket |> List.filter (fun (k, _) -> k <> key)
        |> fun b -> (key, value) :: b
    let newBuckets =
        map.buckets
        |> List.mapi (fun i b -> if i = idx then updatedBucket else b)
    { map with buckets = newBuckets }

/// Удаление элемента по ключу
let remove (key: 'K) (map: HashMap<'K, 'V>) : HashMap<'K, 'V> =
    let idx = bucketIndex map.capacity key
    let bucket = List.item idx map.buckets
    let updatedBucket = bucket |> List.filter (fun (k, _) -> k <> key)
    let newBuckets =
        map.buckets
        |> List.mapi (fun i b -> if i = idx then updatedBucket else b)
    { map with buckets = newBuckets }

/// Поиск значения по ключу
/// Возвращает Some value, если найден, иначе None
let tryFind (key: 'K) (map: HashMap<'K, 'V>) : 'V option =
    let idx = bucketIndex map.capacity key
    map.buckets
    |> List.item idx
    |> List.tryFind (fun (k, _) -> k = key)
    |> Option.map snd

/// Проверка наличия ключа
let containsKey (key: 'K) (map: HashMap<'K, 'V>) : bool =
    match tryFind key map with
    | Some _ -> true
    | None -> false

/// применяет функцию f к каждому значению
let mapValues (f: 'V -> 'U) (map: HashMap<'K, 'V>) : HashMap<'K, 'U> =
    let newBuckets =
        map.buckets
        |> List.map (fun bucket -> bucket |> List.map (fun (k, v) -> (k, f v)))
    { buckets = newBuckets; capacity = map.capacity }

/// Фильтрация по условию (ключ, значение)
let filter (pred: 'K -> 'V -> bool) (map: HashMap<'K, 'V>) : HashMap<'K, 'V> =
    let newBuckets =
        map.buckets
        |> List.map (fun bucket -> bucket |> List.filter (fun (k, v) -> pred k v))
    { map with buckets = newBuckets }

/// Левая свертка
let fold (f: 'S -> 'K -> 'V -> 'S) (state: 'S) (map: HashMap<'K, 'V>) : 'S =
    map.buckets
    |> List.fold (fun acc bucket ->
        bucket |> List.fold (fun acc' (k, v) -> f acc' k v) acc) state

/// Правая свертка
let foldBack (f: 'K -> 'V -> 'S -> 'S) (state: 'S) (map: HashMap<'K, 'V>) : 'S =
    map.buckets
    |> List.foldBack (fun (bucket: Chain<'K, 'V>) acc ->
        List.foldBack (fun (k, v) acc' -> f k v acc') bucket acc) state

/// Объединение двух HashMap
/// При конфликте — выбирается значение из второго HashMap.
let combine (map1: HashMap<'K, 'V>) (map2: HashMap<'K, 'V>) : HashMap<'K, 'V> =
    fold (fun acc k v -> add k v acc) map2 map1

/// Сравнение двух HashMap по значениям (без сортировки)
/// Pipe-friendly: map1 |> equals map2
let equals (other: HashMap<'K, 'V>) (map: HashMap<'K, 'V>) : bool =
    let allKeys =
        fold (fun s k _ -> Set.add k s) Set.empty map
        |> fun s -> fold (fun s k _ -> Set.add k s) s other
    allKeys
    |> Set.forall (fun k -> tryFind k map = tryFind k other)
