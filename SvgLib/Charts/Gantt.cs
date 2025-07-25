using static SvgLib.SvgColour;
namespace SvgLib;

public record Task(string name, int start, int end);

public class GanttChart {
    private static (int Width, int Height) CANVAS_SIZE = (2000, 500);
    private static int TIME_STEP = 1;
    private static int FONT_SIZE = 24;

    public static Svg Draw(Task[] tasks, string time_scale = "Gantt Chart") {
        int max_time = tasks.Max(x => x.end);

        int num_rows = tasks.Length;
        int num_cols = max_time / TIME_STEP;

        int time_label_height = 50;

        int chart_offset_y = time_label_height;
        int chart_height = CANVAS_SIZE.Height - chart_offset_y;

        int horizontal_lines = tasks.Length;
        int vertical_lines_step = max_time / TIME_STEP;

        int max_len_tasks = Math.Max(time_scale.Length, tasks.Max(x => x.name.Length));
        int task_label_width = max_len_tasks * FONT_SIZE;

        int col_width = (CANVAS_SIZE.Width - task_label_width) / num_cols;
        int row_height = chart_height / num_rows;

        var svg = new SvgLib.Svg(CANVAS_SIZE.Width, CANVAS_SIZE.Height);

        new TextBox(0, 0, time_scale.Length * FONT_SIZE, FONT_SIZE * 2, time_scale)
            .Foreground(BLACK)
            .Background(NONE)
            .Border(NONE)
            .Layer(2)
            .Shapes()
            .AddTo(svg.Shapes);

        // Horizontal Lines
        Enumerable.Range(0, num_rows + 1)
            .Select(x => new Line()
                    .Position(0, chart_offset_y + row_height * x)
                    .Size(CANVAS_SIZE.Width, chart_offset_y + row_height * x)
                    .Border(GRAY))
            .AddTo(svg.Shapes);

        // Verical Lines
        Enumerable.Range(0, vertical_lines_step)
            .Select(x => new Line()
                    .Position(task_label_width + col_width * x, time_label_height)
                    .Size(task_label_width + col_width * x, CANVAS_SIZE.Height + time_label_height)
                    .Border(GRAY))
            .AddTo(svg.Shapes);

        // Colour Squares
        Enumerable.Range(0, tasks.Length)
            .SelectMany(y =>
                    Enumerable.Range(
                        tasks[y].start,
                        tasks[y].end - tasks[y].start)
                    .Select(x => new Rectangle()
                        .Position(
                            task_label_width + col_width * x,
                            (row_height / 6) + chart_offset_y + row_height * y)
                        .Size(col_width, 2 * (row_height / 3))
                        .Background(SvgColour.RandomColour(y))
                        .Layer(4)
                        .Border(NONE)))
            .AddTo(svg.Shapes);


        // Task Labels
        Enumerable.Range(0, horizontal_lines)
            .Select(x => new TextBox(0, chart_offset_y + row_height * x, tasks[x].name)
                    .Background(NONE)
                    .Foreground(BLACK)
                    .Border(NONE))
            .Select(x => x.Shapes())
            .ToList()
            .ForEach(x => x.AddTo(svg.Shapes));

        // Time Step Labels
        Enumerable.Range(0, num_cols)
            .Select(x => new TextBox(
                        (task_label_width + col_width * x)
                        + (int)(0.5 * col_width)
                        - (int)(0.5 * FONT_SIZE),
                        0,
                        col_width,
                        time_label_height,
                        $"{x + 1 * TIME_STEP}"
                        )
                    .Background(NONE)
                    .Foreground(BLACK)
                    .Border(NONE)
                    )
            .Select(x => x.Shapes())
            .ToList()
            .ForEach(x => x.AddTo(svg.Shapes));

        return svg;
    }
}
