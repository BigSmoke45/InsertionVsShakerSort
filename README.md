# DataStructures-Algorithms-CSharp

A collection of classic data structures and algorithm implementations in C#, written from scratch without relying on built-in collection classes.

---

## Contents

### 1. `SortingBenchmark.cs` — Insertion Sort vs Shaker Sort

Benchmarking tool that measures and compares the performance of two O(n²) sorting algorithms across three input scenarios.

**Algorithms:**
- **Insertion Sort** — O(n²) average, O(n) best case. Shifts each element into its correct position in the sorted prefix.
- **Shaker Sort** — O(n²) average, O(n) best case. Bidirectional bubble sort with early-exit optimization.

**Test scenarios per algorithm:**

| Scenario | Description |
|----------|-------------|
| Random | Array of random integers |
| Already sorted | Best case — tests early-exit behavior |
| Reverse sorted | Worst case |

**Array sizes:** 1,000 / 100,000 / 1,000,000 elements (user selects on startup).

Timing is measured with `System.Diagnostics.Stopwatch` at nanosecond precision.

---

### 2. `LinkedListDemo.cs` — Custom Singly Linked List

A generic singly linked list (`CustomLinkedList<T>`) implemented from scratch with 14 interactive operations via a console menu.

**Supported operations:**

| # | Operation |
|---|-----------|
| 1 | Print all elements |
| 2 | Print in reverse order |
| 3 | Count elements |
| 4 | Insert at beginning |
| 5 | Remove last element |
| 6 | Clear list |
| 7 | Insert after i-th element |
| 8 | Insert before i-th element |
| 9 | Append to end |
| 10 | Append same value k times |
| 11 | Build list from range [a, b] |
| 12 | Remove every k-th element |
| 13 | Remove last k elements |
| 14 | Remove element at index i |

**Key implementation details:**
- Generic `Node<T>` and `CustomLinkedList<T>` — no `System.Collections.Generic.LinkedList` used
- Manual pointer manipulation for all insert/remove operations
- `FindPrevNode()` helper for reverse traversal and node removal
- Static `Range(a, b)` factory method

---

## Tech Stack

`C#` · `.NET` · `System.Diagnostics.Stopwatch`

---

## Run

Open in Visual Studio or run with .NET CLI:

```bash
# Sorting benchmark
dotnet run --project SortingBenchmark.cs

# Linked list demo
dotnet run --project LinkedListDemo.cs
```

Or create a new Console App project in Visual Studio and replace `Program.cs` with either file.

---

## Notes

University coursework projects. Written to demonstrate understanding of fundamental data structures, algorithm complexity, and manual memory/pointer management in C#.
