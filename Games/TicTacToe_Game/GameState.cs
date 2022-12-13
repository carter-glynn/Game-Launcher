using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    public  class GameState
    {
        public Player[,] Grid { get; private set; }
        public Player currPlayer { get; private set; }
        public int numTurns { get; private set; }
        public bool gameEnd { get; private set; }

        public event Action<int, int> MoveMade;
        public event Action<Result> GameEnded;
        public event Action GameReStart;

        public GameState()
        {
            Grid = new Player[3, 3];
            currPlayer = Player.X;
            numTurns = 0;
            gameEnd = false;
        }

        private bool CanMove(int row, int col)
        {
            if (!gameEnd && Grid[row,col] == Player.Empty) { return true; }
            return false;
        }
        private bool GridFull()
        {
            if (numTurns == 9) { return true; }
            return false;
        }
        private void SwtichPlayer()
        {
            if (currPlayer == Player.X) { currPlayer = Player.O; }
            else { currPlayer = Player.X; }
        }
        private bool GridMarked((int, int)[] tiles, Player player)
        {
            foreach ((int row, int column) in tiles)
            {
                if (Grid[row, column] != player) { return false; }
            }
            return true;     
        }
        private bool GameWonByMove(int rows, int cols, out WinInformation winInformation)
        {
            (int, int)[] row    = new[] { (rows,0), 
                                          (rows,1), 
                                          (rows,2)};
            (int, int)[] column = new[] { (0, cols),
                                          (1, cols),
                                          (2, cols)};
            (int, int)[] LRDiag = new[] { (0, 0),
                                          (1, 1),
                                          (2, 2)};
            (int, int)[] RLDiag = new[] { (0, 2),
                                          (1, 1),
                                          (2, 0)};
            if (GridMarked(row, currPlayer))
            {
                winInformation = new WinInformation { type = WinType.Row, number = rows };
                return true;
            }
            if (GridMarked(column, currPlayer))
            {
                winInformation = new WinInformation { type = WinType.Column, number = cols };
                return true;
            }
            if (GridMarked(LRDiag, currPlayer))
            {
                winInformation = new WinInformation { type = WinType.LRDiagonal };
                return true;
            }
            if (GridMarked(RLDiag, currPlayer))
            {
                winInformation = new WinInformation { type = WinType.RLDiagonal };
                return true;
            }
            winInformation = null;
            return false;
        }
        private bool GameEndByMove(int rows, int cols, out Result result)
        {
            if (GameWonByMove(rows, cols, out WinInformation winInformation))
            {
                result = new Result { winner = currPlayer, winInformation = winInformation };
            }
            if (GridFull())
            {
                result = new Result { winner = Player.Empty };
                return true;
            }
            result = null;
            return false;
        }
        public void MakeMove(int row, int col)
        {
            if (!CanMove(row, col)) { return; }

            Grid[row, col] = currPlayer;
            numTurns++;

            if (GameEndByMove(row, col, out Result result)) 
            { 
                gameEnd = true; 
                
                if (MoveMade != null) { MoveMade(row, col); }
                if (GameEnded != null) { GameEnded(result); }
            }
            else
            {
                SwtichPlayer();
                if (MoveMade != null) { MoveMade(row, col); }
            }
        }
        public void Reset()
        {
            Grid = new Player[3, 3];
            currPlayer = Player.X;
            numTurns = 0;
            gameEnd = false;
            if (GameReStart != null) { GameReStart(); }
        }
    }
}
