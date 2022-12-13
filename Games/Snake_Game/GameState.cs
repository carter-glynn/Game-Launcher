using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class GameState
    {
        public int Rows { get; }
        public int Columns { get; }
        public TileValue[,] Grid { get; }
        public Direction Direction { get; private set; }
        public int Score { get; private set; }
        public bool GameEnd { get; private set; }

        private readonly LinkedList<Direction> dirChange = new LinkedList<Direction>();
        private readonly LinkedList<Position> PositionSnake = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new TileValue[rows, columns];
            Direction = Direction.Right;

            AddSnake();
            AddFood();
        }
        private void AddSnake()
        {
            int r = Rows / 2;
            for (int c = 1; c<=3;c++)
            {
                Grid[r, c] = TileValue.Snake;
                PositionSnake.AddFirst(new Position(r, c));
            }
        }

        private IEnumerable<Position> EmptyPositions()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c< Columns; c++)
                {
                    if (Grid[r, c] == TileValue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPositions());
            if (empty.Count == 0) { return; }
            Position pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Column] = TileValue.Food;
        }

        public Position HeadPosition()
        {
            return PositionSnake.First.Value;
        }
        public Position TailPosition()
        {
            return PositionSnake.Last.Value;
        }

        public IEnumerable<Position> SnakePositions()
        {
            return PositionSnake;
        }
        private void AddHead(Position pos)
        {
            PositionSnake.AddFirst(pos);
            Grid[pos.Row, pos.Column] = TileValue.Snake;
        }

        private void RemoveTail()
        {
            Position tail = PositionSnake.Last.Value;
            Grid[tail.Row, tail.Column] = TileValue.Empty;
            PositionSnake.RemoveLast();
        }

        private Direction GetLastDir()
        {
            if (dirChange.Count == 0) { return Direction; }
            return dirChange.Last.Value;
        }

        private bool CanChangeDir(Direction newDir)
        {
            if (dirChange.Count == 2) { return false; }
            Direction lastDir = GetLastDir();
            return newDir != lastDir && newDir != lastDir.Opposite();
        }

        public void ChangeDirection(Direction dir)
        {
            if (CanChangeDir(dir)) { dirChange.AddLast(dir); }
        }
        
        private bool IsOutside(Position pos)
        {
            if (pos.Row < 0) { return true; }
            if (pos.Row >= Rows) { return true; }
            if (pos.Column < 0) { return true; }
            if (pos.Column >= Columns) { return true; }
            else { return false; }
        }

        private TileValue SnakeHit(Position headPos)
        {
            if (IsOutside(headPos)) { return TileValue.Outside; }
            return Grid[headPos.Row, headPos.Column];
        }
        public void Move()
        {
            if (dirChange.Count > 0) 
            { 
                Direction = dirChange.First.Value; 
                dirChange.RemoveFirst(); 
            }
            
            Position headPos = HeadPosition().Translate(Direction);
            TileValue hit = SnakeHit(headPos);
            
            if (hit == TileValue.Outside || hit == TileValue.Snake) { GameEnd = true; }
            else if (hit == TileValue.Empty) { RemoveTail(); AddHead(headPos); }
            else if (hit == TileValue.Food) { AddHead(headPos); Score++; AddFood(); }
        }
    }
}
