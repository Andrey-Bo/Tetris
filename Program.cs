using System.Runtime.CompilerServices;
using Tetris;

Console.SetWindowSize(40, 30);
Console.SetBufferSize(40, 30);

FigureGenerator generator = new FigureGenerator(20, 0, '*');
Figure figure = generator.GetNewFigure();

while (true)
{
    if (Console.KeyAvailable)
    { 
        ConsoleKeyInfo key = Console.ReadKey();
        HandleKey(figure, key);
    }
}

Console.ReadKey();


static void HandleKey(Figure fig, ConsoleKeyInfo key)
{
    switch (key.Key)
    {
        case ConsoleKey.LeftArrow:
            fig.TryMove(Direction.LEFT);
            break;
        case ConsoleKey.RightArrow:
            fig.TryMove(Direction.RIGHT);
            break;
        case ConsoleKey.DownArrow:
            fig.TryMove(Direction.DOWN);
            break;
        case ConsoleKey.Spacebar:
            fig.Rotate();
            break;
    }
}