<?php
  
/**
 * 
 * Copyright (c) 2005-2015, Braulio Jos� Solano Rojas
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 * 
 * 	Redistributions of source code must retain the above copyright notice, this list of
 * 	conditions and the following disclaimer. 
 * 	Redistributions in binary form must reproduce the above copyright notice, this list of
 * 	conditions and the following disclaimer in the documentation and/or other materials
 * 	provided with the distribution. 
 * 	Neither the name of the Solsoft de Costa Rica S.A. nor the names of its contributors may
 * 	be used to endorse or promote products derived from this software without specific
 * 	prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
 * CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
 * OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 *
 * @version $Id$
 * @copyright 2005-2015
 */


/**
 * HolaMundo Clase que implementa el t�pico primer ejemplo de programaci�n en todo lenguaje.
 * 
 * @package SoapDiscovery
 * @author Braulio Jos� Solano Rojas
 * @copyright Copyright (c) 2005-2015 Braulio Jos� Solano Rojas
 * @version $Id$
 * @access public
 **/

class TicTacToe {
    private $board = array(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
    private $corners = array(1, 3, 7, 9);

    private $PLAYER_ID = 0;
    private $PC_ID = 1;

    private $PC_WINNER = -1000;
    private $PLAYER_WINNER = 1000;
    private $DRAW = 0;

	/**
	 * TicTacToe::__construct() Constructor de la clase TicTacToe.
	 * 
	 * @param int $nextMove
	 **/
	public function __construct(){}

    /**
     * TicTacToe::isWinner() Determina si el jugador ha ganado la partida.
     * @param array $board
     * @param array $playerId
     * @return bool
     **/
    private function isWinner($board, $playerId){
        return (($board[1] == $playerId and $board[2] == $playerId and $board[3] == $playerId) or
                ($board[4] == $playerId and $board[5] == $playerId and $board[6] == $playerId) or
                ($board[7] == $playerId and $board[8] == $playerId and $board[9] == $playerId) or
                ($board[1] == $playerId and $board[4] == $playerId and $board[7] == $playerId) or
                ($board[2] == $playerId and $board[5] == $playerId and $board[8] == $playerId) or
                ($board[3] == $playerId and $board[6] == $playerId and $board[9] == $playerId) or
                ($board[1] == $playerId and $board[5] == $playerId and $board[9] == $playerId) or
                ($board[7] == $playerId and $board[5] == $playerId and $board[3] == $playerId));
    }
    
    public function resetBoard(){
        for ($index = 1; $index < count($this->board); $index++){
            $this->board[$index] = -1;
        }
    }

    /**
     * TicTacToe::doMove() 
     * @param string $board
     * @return string
     **/
    public function doMove($moveIndex){
        $this->board[$moveIndex] = 0;

        if ($this->isWinner($this->board, $this->PLAYER_ID))
            return $this->PLAYER_WINNER;

        if (count($this->getFreeCells()) == 0)
            return $this->DRAW;

        $computerMove = $this->computerMove();
        $this->board[$computerMove] = 1;

        return $computerMove;
    }

    public function getBoardStatus() {
        if ($this->isWinner($this->board, $this->PC_ID))
            return $this->PC_WINNER;
        if (count($this->getFreeCells()) == 0)
            return $this->DRAW;        
        return -1;
    }

    /**
	 * TicTacToe::computerMove() Realiza el movimiento de la computadora.
     * La estrategia huerística es la siguiente. 
     * 1) Primero realizar una búsqueda exhaustiva para determinar si puede ganar.
     * 2) Sino puede ganar, determinar si esta perdiendo en el siguiente turno.
     * 3) Sino gana o pierde, juega alguna esquina si puede.
     * 4) Sino, juega cualquiera de las casillas disponibles.
	 * @return string
	 **/
    private function computerMove() {
        $winningMove = $this->getWinningMove($this->PC_ID);
        if ($winningMove != -1){
            $this->board[$winningMove] = 1;    
            return $winningMove;
        }

        $losingMove = $this->getWinningMove($this->PLAYER_ID);
        if ($losingMove != -1){
            $this->board[$losingMove] = 1;    
            return $losingMove;
        }

        $cornerMove = $this->getRandomFromOptions($this->getFreeCorners());
        if ($cornerMove == -1){
            $move = $this->getRandomFromOptions($this->getFreeCells());
            $this->board[$move] = 1;
            return $move;
        } else {
            $this->board[$cornerMove] = 1;
            return $cornerMove;
        }
    }

    private function getFreeCorners(){
        $freeCorners = array();
        for ($index = 1; $index < count($this->corners); $index++){
            if ($this->board[$this->corners[$index]] == -1){
                array_push($freeCorners, $this->corners[$index]);
            }
        }
        return $freeCorners;
    }

    private function getWinningMove($player) {
        for ($index = 1; $index < count($this->board); $index++){
            if ($this->board[$index] == -1){
                $board_copy = $this->board;
                $board_copy[$index] = $player;
                if ($this->isWinner($board_copy, $player))
                    return $index;
            }
        }
        return -1;
    }

    private function getRandomFromOptions($options) {
        if (count($options) == 0)
            return -1;
        return $options[array_rand($options, 1)];
    }

    private function getFreeCells() {
        $freeCells = array();
        for ($index = 1; $index < count($this->board); $index++){
            if ($this->board[$index] == -1){
                array_push($freeCells, $index);
            }
        }
        return $freeCells;
    }
}

?>
