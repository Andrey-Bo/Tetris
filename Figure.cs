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

        public Result TryMove(Direction dir)
        {
            Hide();
            Move(dir);
            var result = VerifyPosition();
            if(result!=Result.SUCCESS)
                Move(Reverse(dir));

            Draw();
            return result;
        }

        public void Move(Direction dir)
        {
            foreach (Point p in Points)
            {
                p.Move(dir);
            }
        }

        public Result TryRotate()
        {
            Hide();
            Rotate();
            var result = VerifyPosition();
            if(result!=Result.SUCCESS)
                Rotate();

            Draw();
            return result;
        }

        private Result VerifyPosition()
        {
            foreach (Point p in Points)
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

        Direction Reverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.LEFT: return Direction.RIGHT;
                case Direction.RIGHT: return Direction.LEFT;
                case Direction.DOWN: return Direction.UP;
                case Direction.UP: return Direction.DOWN;
            }
            return dir;
        }

        public abstract void Rotate();

    }
}
