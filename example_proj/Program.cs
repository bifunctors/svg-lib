using SvgLib;

SvgLib.Task[] tasks = [
    new SvgLib.Task("Task One", 0, 1.Weeks()),
    new SvgLib.Task("Task Two", 1.Weeks(), 1.Weeks() + 2.Days()),
    new SvgLib.Task("Task Three", 1.Weeks() + 2.Days(), 2.Weeks()),
];

var svg = GanttChart.Draw(tasks);

svg.Serialize(string.Empty);

Console.WriteLine("Serialized");
