using System;
using System.Collections.Generic;


namespace ConsoleSnake
{
    struct Position
    {
        public int X_cord { get; set; }
        public int Y_cord { get; set; }
    }

    class Snake
    {

        public Snake(in Window window)
        {
            this.window = window;
            SetHeadPosition(window);
        }

        public Snake(in int width = 30, in int height = 10)
        {
            window = new Window(width, height);
            SetHeadPosition(window);
        }

        public bool S_up()
        {
            char cell = window.arr[headPosition.Y_cord - 1, headPosition.X_cord];
            temp = headPosition;
            if (cell == ' ')
            {
                headPosition.Y_cord--;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                headPosition.Y_cord--;
                window.AppleUpdate();
                positionsSnake.Add(headPosition);
                SnakeUpdate();
                return true;
            }
            return false;
        }
        public bool S_left()
        {
            char cell = window.arr[headPosition.Y_cord, headPosition.X_cord - 1];
            temp = headPosition;
            if (cell == ' ')
            {
                headPosition.X_cord--;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                window.AppleUpdate();
                positionsSnake.Add(headPosition);
                headPosition.X_cord--;
                SnakeUpdate();
                return true;
            }
            return false;
        }
        public bool S_right()
        {
            char cell = window.arr[headPosition.Y_cord, headPosition.X_cord + 1];
            temp = headPosition;
            if (cell == ' ')
            {
                headPosition.X_cord++;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                window.AppleUpdate();
                positionsSnake.Add(headPosition);
                headPosition.X_cord++;
                SnakeUpdate();
                return true;
            }
            return false;
        }
        public bool S_down()
        {
            char cell = window.arr[headPosition.Y_cord + 1, headPosition.X_cord];
            temp = headPosition;
            if (cell == ' ')
            {
                headPosition.Y_cord++;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                window.AppleUpdate();
                positionsSnake.Add(headPosition);
                headPosition.Y_cord++;
                SnakeUpdate();
                return true;
            }
            return false;
        }

        public ref List<Position> GetPositions()
        {
            return ref positionsSnake;
        }

        public int GetPoints()
        {
            return positionsSnake.Count - 1;
        }

        private void SetHeadPosition(in Window window)
        {
            headPosition.X_cord = window.width / 2;
            headPosition.Y_cord = window.height / 2;
            positionsSnake.Add(headPosition);
        }

        private void SnakeUpdate()
        {
            positionsSnake.RemoveAt(0);
            positionsSnake.Insert(0, headPosition);
            if (positionsSnake.Count > 1)
            {
                positionsSnake.Insert(1, temp);
                positionsSnake.RemoveAt(positionsSnake.Count - 1);
            }
            window.UpdateWindowWithSnake(positionsSnake, positionsSnake.Count - 1);
        }


        private List<Position> positionsSnake = new List<Position>();
        private Position headPosition;
        private Position temp;
        private Window window;
    }
}
