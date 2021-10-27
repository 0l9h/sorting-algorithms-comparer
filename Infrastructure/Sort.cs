using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_7.Models;

namespace Lab_7.Infrastructure
{
    public delegate long ProcessSorting(int[] arrToSort);
    public class Sort
    {
        public SortModel Model { get; set; }

        public int[] arr;
        private readonly int N;
        public Sort(SortModel model)
        {
            Model = model;
            N = model.ValuesNumber;
            InitializeArray();
        }
        private void InitializeArray()
        {
            arr = new int[N];
            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                arr[i] = rand.Next()%1000000;
            }
        }
        public void DoSort(object o)
        {
            var func = o as ProcessSorting;
            int[] _arr = new int[N];
            arr.CopyTo(_arr, 0);

            Model.AlgorithmsTimeElapsed[func.Method.Name] = func(_arr);

        }
    }
}
