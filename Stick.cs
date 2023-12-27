using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Stick:Figure
    {

        public Stick(int x,int y, char c) 
        {
            Points[0] = new Point(x,y,c);
            Points[1] = new Point(x,y+1,c);
            Points[2] = new Point(x,y+2,c);
            Points[3] = new Point(x,y+3,c);
            Draw();
        }

        public override void Rotate()
        {
            if (Points[0].x == Points[1].x) SetHorizontal();
            else SetVertical();
        }

        private void SetHorizontal()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].y= Points[0].y;
                Points[i].x = Points[0].x+i;
            }
        }

        private void SetVertical()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].x = Points[0].x;
                Points[i].y = Points[0].y + i;
            }
        }

    }
}
