using System.Runtime.CompilerServices;
using Tetris;
using System.Timers;

const int TIMER_INTERVAL = 500;
System.Timers.Timer timer;
Object _lockObject = new object();

Console.SetWindowSize(Field.Width, Field.Height);
Console.SetBufferSize(Field.Width, Field.Height);

FigureGenerator generator = new FigureGenerator(Field.Width/2, 0, Drawer.DEF_SYMBOL);
Figure figure = generator.GetNewFigure();
SetTimer();
int exit = 0;
while (exit==0)
{
    if (Console.KeyAvailable)
    { 
        ConsoleKeyInfo key = Console.ReadKey();
        Monitor.Enter(_lockObject);
        var result = HandleKey(figure, key);
        ProcessResult(result,ref figure);
        Monitor.Exit(_lockObject);
        if (key.Key == ConsoleKey.Escape) exit = 1;
    }
}

Console.ReadKey();

 bool ProcessResult(Result result, ref Figure figure)
{
    if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
    {
        Field.AddFigure(figure);
        Field.TryDeleteLines();

        if (figure.IsOnTop())
        {
            WriteGameOver();
            timer.Elapsed -= OnTimedEvent;
            return true;
        }
        else
        {
            figure = generator.GetNewFigure();
            return false;
        }
    }
    else return false;
}

static Result HandleKey(Figure fig, ConsoleKeyInfo key)
{
    switch (key.Key)
    {
        case ConsoleKey.LeftArrow:
            return fig.TryMove(Direction.LEFT);
        case ConsoleKey.RightArrow:
            return fig.TryMove(Direction.RIGHT);
        case ConsoleKey.DownArrow:
            return fig.TryMove(Direction.DOWN);
        case ConsoleKey.Spacebar:
            return fig.TryRotate();
    }
    return Result.SUCCESS;
}

void SetTimer()
{ 
    timer = new System.Timers.Timer(TIMER_INTERVAL);
    timer.Elapsed += OnTimedEvent;
    timer.AutoReset = true;
    timer.Enabled = true;
}

void OnTimedEvent(object sender,ElapsedEventArgs e)
{
    Monitor.Enter(_lockObject);
    var result = figure.TryMove(Direction.DOWN);
    ProcessResult(result, ref figure);
    Monitor.Exit(_lockObject);
}

void WriteGameOver()
{
    Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height / 2);
    Console.WriteLine("G A M E   O V E R");
}