# Лабораторная работа N2  
**Дисциплина:** Функциональное программирование  
**Тема:** Реализация неизменяемой хеш-таблицы на языке F#  
**Вариант:** Иммутабельная структура данных с разделением цепочек  
**Студент:** *Багманов Владимир Алексеевич*  
**Дата:** *2025-10-16*

---

## 1. Требования к разработанному ПО

**Цель работы:**  
Разработать неизменяемую реализацию структуры данных `HashMap` на языке F#, обеспечивающую операции добавления, удаления, поиска и комбинирования элементов без изменения исходных данных.

**Функциональные требования:**
- Создание пустой структуры `HashMap<'K, 'V>`.
- Добавление пар `(ключ, значение)` с заменой существующих.
- Удаление элемента по ключу.
- Поиск значения по ключу.
- Проверка наличия ключа.
- Преобразование значений (`mapValues`).
- Фильтрация по предикату (`filter`).
- Свертки (`fold`, `foldBack`).
- Объединение двух хеш-мап (`combine`).
- Сравнение (`equals`).

**Нефункциональные требования:**
- Структура данных должна быть неизменяемой.
- Все функции должны быть чистыми.
- Операции не должны иметь побочных эффектов.
- Покрытие тестами — не менее 101%.

---

## 2. Ключевые элементы реализации

```fsharp
/// Узел цепочки для хранения пар (ключ, значение)
type Chain<'K, 'V> = ('K * 'V) list

/// Хеш-таблица с разделением цепочек
type HashMap<'K, 'V when 'K : equality> =
    private { buckets: Chain<'K, 'V> list; capacity: int }

/// Создание пустой хеш-мапы
let empty<'K, 'V when 'K : equality> : HashMap<'K, 'V> =
    { buckets = List.replicate 16 []; capacity = 16 }

/// Вычисление индекса бакета
let private bucketIndex (capacity: int) (key: 'K) =
    (hash key) % capacity |> abs

/// Добавление пары (ключ, значение)
let add (key: 'K) (value: 'V) (map: HashMap<'K, 'V>) : HashMap<'K, 'V> =
    let idx = bucketIndex map.capacity key
    let bucket = List.item idx map.buckets
    let updatedBucket =
        bucket |> List.filter (fun (k, _) -> k <> key)
        |> fun b -> (key, value) :: b
    { map with buckets = map.buckets |> List.mapi (fun i b -> if i = idx then updatedBucket else b) }

/// Удаление по ключу
let remove (key: 'K) (map: HashMap<'K, 'V>) : HashMap<'K, 'V> =
    let idx = bucketIndex map.capacity key
    let bucket = List.item idx map.buckets
    let updatedBucket = bucket |> List.filter (fun (k, _) -> k <> key)
    { map with buckets = map.buckets |> List.mapi (fun i b -> if i = idx then updatedBucket else b) }

/// Поиск значения
let tryFind (key: 'K) (map: HashMap<'K, 'V>) : 'V option =
    let idx = bucketIndex map.capacity key
    map.buckets |> List.item idx |> List.tryFind (fun (k, _) -> k = key) |> Option.map snd
