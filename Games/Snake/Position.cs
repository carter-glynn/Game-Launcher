using System;
using System.Collections.Generic;

namespace Snake_Game
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Position Translate(Direction direction)
        {
            return new Position(Row + direction.RowOffset, Column + direction.ColumnOffset);
        }

        //next four functions allow direction to be used as a key in a dictionary
        //these functions are generated with visual studio using ctrl+. and selecting "Generate Eqwuals and GetHashCode"
        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Position left, Position right)
        {
            //overloads equality operator to compare positions
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            //overloadsinequality operator to compare positions
            return !(left == right);
        }
    }
}
