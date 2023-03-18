/// <summary>
/// Utilities for working with heaps
/// </summary>
public class Heap
{

    /// <summary>
    /// Converts array into a heap
    /// </summary>
    public static void BuildHeap(int[] numbers)
    {
        // Don't need to Heapify leaf nodes.
        for (int i = (numbers.Length / 2 - 1); i > -1; i--)
        {
            Heapify(numbers, i);
        }
    }

    /// <summary>
    /// Fixes the order property violation of the heap at the given index.
    /// </summary>
    public static void Heapify(int[] numbers, int index, int? heapSize = null)
    {
        if (!IsLeaf(numbers, index, heapSize))
        {
            int maxChildIdx = GetMaxChildIdx(numbers, index, heapSize);
            if (numbers[index] < numbers[maxChildIdx])
            {
                (numbers[index], numbers[maxChildIdx]) = (numbers[maxChildIdx], numbers[index]);
                Heapify(numbers, maxChildIdx, heapSize);
            }
        }
    }

    /// <summary>
    /// Returns true if the node at the given index is a leaf node.
    /// </summary>
    private static bool IsLeaf(int[] numbers, int index, int? heapSize)
    {
        int len = heapSize ?? numbers.Length;
        if (index > (len / 2 - 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Returns the child of the node at <c>index</c> with the maximum key.
    /// </summary>
    private static int GetMaxChildIdx(int[] numbers, int index, int? heapSize)
    {
        int len = heapSize ?? numbers.Length;
        (int? firstChildIdx, int? secondChildIdx) = GetChildIdx(len, index);

        if (firstChildIdx != null && secondChildIdx == null)
        {
            return firstChildIdx.Value;
        }
        else if (firstChildIdx != null && secondChildIdx != null)
        {
            return numbers[firstChildIdx.Value] > numbers[secondChildIdx.Value]
                    ? firstChildIdx.Value
                    : secondChildIdx.Value;
        } else {
            throw new ApplicationException("Invalid state");
        }
    }

    /// <summary>
    /// Returns the indices of children of node at <c>index</c>. Returns null for each child that does not exist.
    /// </summary>
    private static (int?, int?) GetChildIdx(int len, int index)
    {
        int? firstChildIdx = len > index * 2 + 1 ? index * 2 + 1 : null;
        int? secondChildIdx = len > index * 2 + 2 ? index * 2 + 2 : null;

        return (firstChildIdx, secondChildIdx);
    }
}
