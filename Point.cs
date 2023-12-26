using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Point
    {
        public int x=0, y=0;
        public char c='.';

        public Point() { }

        public Point(int _x,int _y,char _c)
        {
            x= _x;
            y= _y;
            c= _c;

        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        internal void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    y += 1;
                    break;
                case Direction.LEFT:
                    x -= 1;
                    break;
                case Direction.RIGHT:
                    x += 1;
                    break;

            }

        }
    }
}
