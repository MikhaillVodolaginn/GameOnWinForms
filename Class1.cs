using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyGame.Model
{
    public enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum States
    {
        Empty,
        BlackWall,
        BlueWall,
        RedWall,
        YellowWall,
        GreenWall
    }

    public class Player
    {
        public Vector Position { get; private set; }

        public Player (Vector position)
        {
            Position = position;
        }

        public bool CanMove(Map map, Vector position)
        {
            return position.X >= 0 && position.X < map.Weight && position.Y >= 0 && position.Y < map.Height;
        }

        public Vector Move(Map map, Directions direction)
        {
            switch (direction)
            {
                case Directions.Left:
                    if (CanMove(map, new Vector(Position.X - 1, Position.Y)))
                        Position = new Vector(Position.X - 1, Position.Y);
                    break;

                case Directions.Right:
                    if (CanMove(map, new Vector(Position.X + 1, Position.Y)))
                        Position = new Vector(Position.X + 1, Position.Y);
                    break;

                case Directions.Up:
                    if (CanMove(map, new Vector(Position.X, Position.Y - 1)))
                        Position = new Vector(Position.X, Position.Y - 1);
                    break;

                case Directions.Down:
                    if (CanMove(map, new Vector(Position.X, Position.Y + 1)))
                        Position = new Vector(Position.X, Position.Y + 1);
                    break;
            }

            return Position;
        }

        public bool CanActivate(Cell cell)
        {
            return !(cell.State == States.Empty || cell.State == States.BlackWall);
        }

        public bool CanBreakDown(Cell cell, int count)
        {
            return count > 0 && cell.State != States.Empty;
        }
    }

    public class Cell
    {
        private readonly Point position;

        public States State { get; private set; }

        public Cell (Point coordinates, States state)
        {
            position = coordinates;
            State = state;
        }

        public void Activate()
        {
            State = States.BlackWall;
        }

        public void BreakDown()
        {
            State = States.Empty;
        }

        public bool CanActivate()
        {
            return !(State == States.Empty || State == States.BlackWall);
        }

        public bool CanBreakDown(int count)
        {
            return count > 0 && State != States.Empty;
        }
    }

    public class Map
    {
        public int Weight { get; }
        public int Height { get; }

        public Map (int weight, int height)
        {
            Weight = weight;
            Height = height;
        }
    }
}
