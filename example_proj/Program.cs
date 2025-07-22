using static SvgLib.SvgColour;
using SvgLib;

Console.WriteLine("Serializing SVG");

Task[] Tasks = [
    NewTask("Task One", 0, 1),
    NewTask("Task Two", 1, 2),
    NewTask("Task Three", 2, 3),
    NewTask("Task Four", 3, 7),
];

int CANVAS_WIDTH = 2000;
int CANVAS_HEIGHT = 500;

int max_time = 20;
int time_per_cell = 1;

int num_rows = Tasks.Length;
int num_cols = max_time / time_per_cell;

int time_label_height = 50;

int chart_offset_y = time_label_height;
int chart_height = CANVAS_HEIGHT - chart_offset_y;

int horizontal_lines = Tasks.Length;
int vertical_lines_step = max_time / time_per_cell;

int max_len_tasks = Tasks.Max(x => x.name.Length);
int task_label_width = max_len_tasks * 24;

int col_width = (CANVAS_WIDTH - task_label_width) / num_cols;
int row_height = chart_height / num_rows;

var svg = new SvgLib.Svg(CANVAS_WIDTH, CANVAS_HEIGHT);

// Canvas Border
svg.Shapes.Add(
        new Rectangle()
            .Position(0, 0)
            .Size(CANVAS_WIDTH, CANVAS_HEIGHT)
            .Background(NONE)
            .Border(BLACK)
        );

// Horizontal Lines
Enumerable.Range(0, num_rows + 1)
    .Select(x => new Line()
            .Position(0, chart_offset_y + row_height * x)
            .Size(CANVAS_WIDTH, chart_offset_y + row_height * x)
            .Border(GRAY))
    .Cast<Shape>()
    .ToList()
    .ForEach(svg.Shapes.Add);

// Verical Lines
Enumerable.Range(0, vertical_lines_step)
    .Select(x => new Line()
            .Position(task_label_width + col_width * x, time_label_height)
            .Size(task_label_width + col_width * x, CANVAS_HEIGHT + time_label_height)
            .Border(BLACK))
    .Cast<Shape>()
    .ToList()
    .ForEach(svg.Shapes.Add);

// Colour Squares
Enumerable.Range(0, Tasks.Length)
    .SelectMany(x =>
            Enumerable.Range(
                Tasks[x].start,
                Tasks[x].end - Tasks[x].start)
            .Select(y => new Rectangle()
                .Position(
                    task_label_width + col_width * y,
                    chart_offset_y + row_height * x)
                .Size(col_width, row_height)
                .Background(SvgColour.RandomColour(x))
                .Border(NONE)))
    .ToList()
    .ForEach(svg.Shapes.Add);


// Task Labels
Enumerable.Range(0, horizontal_lines)
    .Select(x => new TextBox(0, chart_offset_y + row_height * x, Tasks[x].name)
            .Background(NONE)
            .Foreground(BLACK)
            .Border(NONE))
    .Select(x => x.Shapes())
    .ToList()
    .ForEach(svg.Shapes.AddRange);

// Time Step Labels
Enumerable.Range(0, num_cols)
    .Select(x => new TextBox(
                task_label_width + col_width * x,
                0,
                col_width,
                time_label_height,
                $"{x * time_per_cell}"
                )
            .Background(NONE)
            .Foreground(BLACK)
            .Border(NONE)
            )
    .Select(x => x.Shapes())
    .ToList()
    .ForEach(svg.Shapes.AddRange);

svg.Serialize("Resources/example.svg");

Console.WriteLine("Serialized");

Task NewTask(string name, int start, int end) => new Task(name, start, end);
record Task(string name, int start, int end);
