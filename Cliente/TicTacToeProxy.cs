using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolaMundo
{
    class TicTacToeProxy
    {
        private readonly ECCI_TicTacToe.ECCI_TicTacToePortClient webService;
        public TicTacToeProxy() {
            webService = new ECCI_TicTacToe.ECCI_TicTacToePortClient();
        }

        /*
         * 
         */
        public int DoMove(int moveIndex) {
            // Jugador 0, Computadora 1.
            int computerMove = webService.doMove(moveIndex);
            return computerMove;
        }
        
        public void ResetBoard()
        {
            webService.resetBoard();
        }

        public int GetBoardStatus()
        {
            return webService.getBoardStatus();
        }
    }
}
