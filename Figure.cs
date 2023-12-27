using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        const int F_LEN = 4;
        public Point[] Points = new Point[F_LEN];

        public void Draw()
        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }

        private Point[] Clone()
        {
            Point[] newPoints = new Point[F_LEN];
            for (int i=0; i < F_LEN; i++)
            { newPoints[i] = new Point(Points[i]); }
            return newPoints;

        }

        public Result TryMove(Direction dir)
        {
            Hide();
            Point[] clone = Clone();
            Move(clone, dir);
            var result = VerifyPosition(clone);
            if(result==Result.SUCCESS)
                Points = clone;

            Draw();
            return result;
        }

        public void Move(Point[] pList,Direction dir)
        {
            foreach (Point p in pList)
            {
                p.Move(dir);
            }
        }

        public void Move(Direction dir)
        {
            Hide();
            foreach (Point p in Points)
            {
                p.Move(dir);
            }
            Draw();
        }

        public Result TryRotate()
        {
            Hide();
            Point[] clone = Clone();
            Rotate(clone);
            var result = VerifyPosition(clone);
            if(result==Result.SUCCESS)
                Points = clone;

            Draw();
            return result;
        }

        private Result VerifyPosition(Point[] pList)
        {
            foreach (Point p in pList)
            {
                if (p.y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;
                if (p.x < 0 || p.y < 0 || p.x >= Field.Width)
                    return Result.BORDER_STRIKE;
                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;

            }
            return Result.SUCCESS;
        }

        public void Hide()
        {
            foreach (Point p in Points)
            {
                p.Hide();
            }
        }

        public bool IsOnTop()
        {
            return Points[0].y == 0;
        }

        public abstract void Rotate(Point[] points);

    }
}
