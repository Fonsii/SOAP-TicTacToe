using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolaMundo
{
    class TicTacToeProxy
    {
        private ECCI_TicTacToe.ECCI_TicTacToePortClient webService;
        public TicTacToeProxy() {
            webService = new HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePortClient();
        }

        public string DoMove(int move) {
            return webService.doMove(move);
        }
    }
}
