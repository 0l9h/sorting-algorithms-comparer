using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace Lab_7.Models
{
    public class SortModel
    {
        public bool IsBubbleSortEnabled { get; set; } = false;
        public bool IsSelectionSortEnabled { get; set; } = false;
        public bool IsShellSortEnabled { get; set; } = false;
        public bool IsQuickSortEnabled { get; set; } = false;
        public bool IsMergeSortEnabled { get; set; } = false;
        public bool IsCountingSortEnabled { get; set; } = false;
        public Dictionary<string, long> AlgorithmsTimeElapsed { get; set; } = new Dictionary<string, long>();
       // public List<string> Algorithms { get; set; } = new List<string>();
        public int ValuesNumber { get; set; }
        // public List<long> TimeElapsed { get; set; } = new List<long>();

        public SortModel()
        {
            AlgorithmsTimeElapsed.Add(
                "BubbleSort", 0);
            AlgorithmsTimeElapsed.Add(
                "SelectionSort", 0);
            AlgorithmsTimeElapsed.Add(
               "ShellSort", 0);
            AlgorithmsTimeElapsed.Add(
                "QuickSort", 0);
            AlgorithmsTimeElapsed.Add(
                 "MergeSort", 0);
            AlgorithmsTimeElapsed.Add(
                "CountingSort", 0);
        }
    }
}
