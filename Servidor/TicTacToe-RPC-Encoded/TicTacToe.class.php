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
    private $board = array(-1, -1, -1, -1, -1, -1, -1, -1, -1);
	private $nextMove = 0;

	/**
	 * TicTacToe::__construct() Constructor de la clase TicTacToe.
	 * 
	 * @param int $nextMove
	 **/
	public function __construct() {
	}

    /**
     * TicTacToe::doMove() Realiza el siguiente movimiento.
     * 
     * @param int $move
     * @return string
     **/
    public function doMove($move){

        if ($this->nextMove == 0){
            if ($this->playerMove($move) === "0"){
                $this->nextMove = 1;
                return "0";
            }else{
                return "1";
            }
        }else{
            $this->nextMove = 0;
            return $this->computerMove();
        }
    }
	
	/**
	 * TicTacToe::playerMove() Realiza el movimiento del jugador.
	 * 
	 * @param int $move
	 * @return string
	 **/
    private function playerMove($move) {
        if ($this->board[$move] == -1){
            $this->board[$move] = 0;
            return "0";
        }
        else{
            return "1";
        }
    }

    public function newFunction($arrayOfInts) {
        return $arrayOfInts;
    }

    /**
	 * TicTacToe::computerMove() Realiza el movimiento de la computadora.
	 * @return string
	 **/
    private function computerMove() {
        $move = rand(0,8);
        while ($this->board[$move] != -1) {
            $move = rand(0,8);
        }
        $this->board[$move] = 1;
        return "0";
    }
}

?>
