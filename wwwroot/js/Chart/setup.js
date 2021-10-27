var data;
$.ajaxSetup({
    async: false
});
$.getJSON("http://localhost:8000/js/Chart/data.json", function (d) {
        let labels =
        [
            "",
            "BubbleSort",
            "SelectionSort",
            "ShellSort",
            "QuickSort",
            "MergeSort",
            "CountingSort",
        ];
    data = {
        labels: labels,
        datasets: [{
            label: 'Time (ms) elapsed after sorting ' + d.Model.ValuesNumber + ' elements',
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: [0,
                d.Model.AlgorithmsTimeElapsed.BubbleSort,
                d.Model.AlgorithmsTimeElapsed.SelectionSort,
                d.Model.AlgorithmsTimeElapsed.ShellSort,
                d.Model.AlgorithmsTimeElapsed.QuickSort,
                d.Model.AlgorithmsTimeElapsed.MergeSort,
                d.Model.AlgorithmsTimeElapsed.CountingSort],
        }]

    }
}).fail(function () {
    console.log("An error has occurred.");
});

