﻿using SnakeConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class Snake : Shape
    {
        DirectionEnum _direction;

        public Snake()
        {
            _points = new List<Point>();
        }

        public Snake CreateSnake(int lenth, Point snakeTail, DirectionEnum direction)
        {
            _direction = direction;
            for (int i = 0; i < lenth; i++)
            {
                Point point = new Point(snakeTail);
                point.SetDiracrion(i, direction);
                _points.Add(point);
            }
            return new Snake();
        }

        public void Move()
        {
            Point tail = _points.First();
            _points.Remove(tail);

            Point head = new Point(_points.Last());
            head.SetDiracrion(1, _direction);
            _points.Add(head);

            tail.ClearPoint();
            head.DrawPoint();
        }

        public void PressKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                _direction = DirectionEnum.Left;
            else if (key == ConsoleKey.RightArrow)
                _direction = DirectionEnum.Right;
            else if (key == ConsoleKey.UpArrow)
                _direction = DirectionEnum.Up;
            else if (key == ConsoleKey.DownArrow)
                _direction = DirectionEnum.Down;
        }

        public bool CollisionWithOwnTail()
        {
            Point head = _points.Last();

            for (int i = 0; i < _points.Count - 1; i++)
            {
                if (head.ComparePoints(_points[i]))
                    return true;
            }
            return false;
        }

        public bool Eat(Point food)
        {
            Point head = new Point(_points.Last());
            head.SetDiracrion(1, _direction);

            if (head.ComparePoints(food))
            {
                food.Symbol = head.Symbol;
                _points.Add(head);
                return true;
            }
            return false;
        }
    }
}
