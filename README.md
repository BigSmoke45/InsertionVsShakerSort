# InsertionSort vs ShakerSort — Benchmarking Tool

A console benchmarking utility written in C# that compares the performance of Insertion Sort and Shaker Sort (bidirectional bubble sort) on integer arrays of different sizes and orderings.

---

## What it measures

Each algorithm is tested on three input scenarios:

| Scenario | Description |
|----------|-------------|
| Random | Array filled with random integers |
| Already sorted | The same array after the first sort pass |
| Reverse sorted | The sorted array reversed — worst case |

This gives 6 measured timings in total (3 scenarios × 2 algorithms), printed to the console with nanosecond precision via `System.Diagnostics.Stopwatch`.

---

## Array sizes

On startup the user selects one of three sizes:

| Option | Size |
|--------|------|
| 1 | 1,000 elements |
| 2 | 100,000 elements |
| 3 | 1,000,000 elements |

---

## Algorithms

**Insertion Sort** — O(n²) average, O(n) best case (already sorted). Classic stable sort. Each element is shifted into its correct position in the already-sorted prefix.

**Shaker Sort** — O(n²) average, O(n) best case. Bidirectional variant of bubble sort: one pass goes left-to-right, the next goes right-to-left. Includes an early-exit flag — stops if no swaps occurred in a full pass.

---

## Tech Stack

`C#` · `.NET` · `System.Diagnostics.Stopwatch`

---

## Run

```bash
dotnet run
```

Or open the `.sln` file in Visual Studio and press F5.

---

## Sample output

```
Час сортування вставками (невідсортований масив):   00:00:00.0123456
Час сортування вставками (відсортований масив):     00:00:00.0000123
Час сортування вставками (зворотний порядок):       00:00:00.0234567
Час шейкерного сортування (невідсортований масив):  00:00:00.0098765
Час шейкерного сортування (відсортований масив):    00:00:00.0000098
Час шейкерного сортування (зворотний порядок):      00:00:00.0187654
```

---

## Notes

University coursework project. Written to demonstrate the practical performance difference between two O(n²) algorithms across best, average, and worst-case inputs.
