using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    class ChessModel
    {
        private bool isTableTurned;
        private List<int[]> chessSquareLogicChords;
        private const int chessTileAmount = 64;

        public ChessModel()
        {
            isTableTurned = false;
            setChessLogicCords();
        }

        public bool IsTableTurned
        {
            get { return isTableTurned; }
        }

        public bool CanTakeCommand
        {
            get;
            set;
        }

        public List<int[]> ChessSquareLogicCords
        {
            get
            {
                return chessSquareLogicChords;
            }
        }

        public void setChessLogicCords()
        {
            chessSquareLogicChords = new List<int[]>(64);
            int xLine = 0;
            int yLine = 0;

            for (int i = 0; i < chessTileAmount; i++)
            {
                chessSquareLogicChords.Add(new int[2] { xLine, yLine });
                xLine++;

                if (xLine == 8)
                {
                    yLine++;
                    xLine = 0;
                }
            }
        }

        public void TurnTable()
        {
            if (IsTableTurned)
            {
                isTableTurned = false;
            }
            isTableTurned = true;
        }

        public void ResetTimeForCommand()
        {
            CanTakeCommand = true;
        }

        public void SetCooldownForCommand()
        {
            CanTakeCommand = false;

            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                ResetTimeForCommand();
                timer.Dispose();

            }, null, 500, System.Threading.Timeout.Infinite);
        }
    }
}
