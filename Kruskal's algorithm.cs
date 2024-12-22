// C# implementation of Heap-Sort:
using System;

class HeapSort
{
    static void Main(string[] args)
    {
        int[] arr = { 17, 21, 13, 5, 2, 19 };
        Console.WriteLine("Original array: " + string.Join(", ", arr));

        PerformHeapSort(arr);
        Console.WriteLine("Sorted array: " + string.Join(", ", arr));
    }

    static void PerformHeapSort(int[] arr)
    {
        int n = arr.Length;


        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }


        for (int i = n - 1; i >= 0; i--)
        {
            Swap(arr, 0, i);
            Heapify(arr, i, 0);
        }
    }

    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;


        if (left < n && arr[left] > arr[largest])
            largest = left;


        if (right < n && arr[right] > arr[largest])
            largest = right;


        if (largest != i)
        {
            Swap(arr, i, largest);
            Heapify(arr, n, largest);
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}


