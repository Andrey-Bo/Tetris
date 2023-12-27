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

        public override void Rotate(Point[] pList)
        {
            if (pList[0].x == pList[1].x) SetHorizontal(pList);
            else SetVertical(pList);
        }

        private void SetHorizontal(Point[] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].y= pList[0].y;
                pList[i].x = pList[0].x+i;
            }
        }

        private void SetVertical(Point[] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].x = pList[0].x;
                pList[i].y = pList[0].y + i;
            }
        }

    }
}
