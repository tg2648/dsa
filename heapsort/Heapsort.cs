public static class Heapsort
{
    /// <summary>
    /// Sorts array in-place using heapsort
    /// </summary>
    public static void Sort(int[] numbers)
    {
        Heap.BuildHeap(numbers);
        int heapSize = numbers.Length;

        for (int i = numbers.Length; i > 1; i--)
        {
            (numbers[0], numbers[i-1]) = (numbers[i-1], numbers[0]);
            heapSize--;
            Heap.Heapify(numbers, 0, heapSize);
        }
    }
}
