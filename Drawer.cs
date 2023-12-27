using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Drawer
    {
        public const char DEF_SYMBOL = '*';

        public static void DrawPoint(int x, int y, char c = DEF_SYMBOL)
        { 
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }

        public static void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }

        public Drawer() { }
    }
}
