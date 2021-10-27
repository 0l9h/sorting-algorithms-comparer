using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_7.Infrastructure
{
    public static class SortingAlgorithms
    {
        public static long BubbleSort(int[] arr)
        {
            var watch = new Stopwatch();
            int n = arr.Length;
            watch.Start();

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

            return watch.ElapsedMilliseconds;
        }

        public static long SelectionSort(int[] arr)
        {
            var watch = new Stopwatch();
            int n = arr.Length;
            watch.Start();

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
            return watch.ElapsedMilliseconds;
        }

        public static long ShellSort(int[] arr)
        {
            var watch = new Stopwatch();
            int n = arr.Length;
            watch.Start();

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        arr[j] = arr[j - gap];
                    arr[j] = temp;
                }
            }
            return watch.ElapsedMilliseconds;
        }

        public static long QuickSort(int[] arr)
        {
            var watch = new Stopwatch();
            int n = arr.Length;
            watch.Start();
            Quick_Sort(arr, 0, n - 1);

            return watch.ElapsedMilliseconds;
        }


        public static long MergeSort(int[] arr)
        {
            var watch = new Stopwatch();
            int n = arr.Length;
            watch.Start();
            Merge_Sort(arr, 0, n - 1);

            return watch.ElapsedMilliseconds;
        }

        public static long CountingSort(int[] array)
        {
            var watch = new Stopwatch();
            watch.Start();
            int[] sortedArray = new int[array.Length];

            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            int[] counts = new int[maxVal - minVal + 1];

            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
            }

            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }
            sortedArray.CopyTo(array,0);
            return watch.ElapsedMilliseconds;
        }

        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }


        private  static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        private static int[] Merge_Sort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                Merge_Sort(array, lowIndex, middleIndex);
                Merge_Sort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }
    }
}
