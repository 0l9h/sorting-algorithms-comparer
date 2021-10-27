using System;
using Lab_7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Lab_7.Infrastructure;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Lab_7.Controllers
{
    public class HomeController : Controller
    {
        public ISession Session { get; set; }

        public HomeController(IServiceProvider provider)
        {
            Session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SortModel model)
        {

            Sort s = new Sort(model);


            Thread th1 = new Thread(s.DoSort);;
            if(s.Model.IsBubbleSortEnabled)
                th1.Start(new ProcessSorting(SortingAlgorithms.BubbleSort));


            Thread th2 = new Thread(s.DoSort);
            if(s.Model.IsSelectionSortEnabled)
                th2.Start(new ProcessSorting(SortingAlgorithms.SelectionSort));
            

            Thread th3 = new Thread(s.DoSort);
            if(s.Model.IsShellSortEnabled)
                th3.Start(new ProcessSorting(SortingAlgorithms.ShellSort));
            

            Thread th4 = new Thread(s.DoSort);
            if(s.Model.IsQuickSortEnabled)
                th4.Start(new ProcessSorting(SortingAlgorithms.QuickSort));


            Thread th5 = new Thread(s.DoSort);
            if(s.Model.IsMergeSortEnabled)
                th5.Start(new ProcessSorting(SortingAlgorithms.MergeSort));


            Thread th6 = new Thread(s.DoSort);
            if(s.Model.IsCountingSortEnabled)
                th6.Start(new ProcessSorting(SortingAlgorithms.CountingSort));



            if(s.Model.IsBubbleSortEnabled)
                th1.Join();

            if(s.Model.IsSelectionSortEnabled)
                th2.Join();

            if(s.Model.IsShellSortEnabled)
                th3.Join();

            if(s.Model.IsQuickSortEnabled)
                th4.Join();

            if(s.Model.IsMergeSortEnabled)
                th5.Join();

            if(s.Model.IsCountingSortEnabled)
                th6.Join();

            string jsonString = JsonSerializer.Serialize(s);
            System.IO.File.WriteAllText("wwwroot/js/Chart/data.json", jsonString);

            return View(model);
        }

    }
}
