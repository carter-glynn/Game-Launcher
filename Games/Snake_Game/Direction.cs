using System;
using System.Collections.Generic;

namespace Snake_Game
{
    public class Direction
    {
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);
        public int RowOffset { get; }
        public int ColumnOffset { get; }

        private Direction (int rowOff, int columnOff)
        {
            RowOffset = rowOff;
            ColumnOffset = columnOff;
        }
        public Direction Opposite()
        {
            return new Direction(-RowOffset, -ColumnOffset);
        }

        //next four functions allow direction to be used as a key in a dictionary
        //these functions are generated with visual studio using ctrl+. and selecting "Generate Eqwuals and GetHashCode"
        public override bool Equals(object obj)
        {
            return obj is Direction direction &&
                   RowOffset == direction.RowOffset &&
                   ColumnOffset == direction.ColumnOffset;
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(RowOffset, ColumnOffset);
        }

        public static bool operator ==(Direction left, Direction right)
        {
            //overloads equality operator to compare directions
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            //overloads inequality operator to compare directions
            return !(left == right);
        }
        //end four functions


    }
}
