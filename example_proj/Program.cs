using static SvgLib.SvgColour;
using SvgLib;

Console.WriteLine("Serializing SVG");

SvgLib.Task[] tasks = [
    new SvgLib.Task("Task One", 0, 1),
    new SvgLib.Task("Task Two", 1, 2),
    new SvgLib.Task("Task Three", 2, 3),
    new SvgLib.Task("Task Four", 3, 7),
];

var svg = GanttChart.Draw(tasks);

svg.Serialize("Resources/example.svg");

Console.WriteLine("Serialized");
