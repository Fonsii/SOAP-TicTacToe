<?php

class TicTacToe {
    private $board = array(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
    private $corners = array(1, 3, 7, 9);
    private $leaderboard = array();
    private $start_time = 0;

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
	public function __construct(){
        $this->start_time = time();
    }

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
        $this->start_time = time();
    }

    public function topPlays(){
        $string_to_return = "Top 10 jugadas \n";
        $leaderboard_txt = fopen('leaderboard.txt', 'r');

        while($entry = fgets($leaderboard_txt))
		{
            $string_to_return .= $entry;
		}

        fclose($leaderboard_txt);

        return $string_to_return;
    }

    private function saveLeaderboard(){
        $leaderboard_txt = fopen('leaderboard.txt', 'w');

        foreach ($this->leaderboard as &$entry) {
            fwrite($leaderboard_txt, $entry->serialize()."\n");
        }
        fclose($leaderboard_txt);
    }

    public function leaderboardCheck($name){
        $leaderboard_txt = fopen('leaderboard.txt', 'r');
        $this->leaderboard = array();

        while($entry = fgets($leaderboard_txt))
		{
			$record = explode(':', $entry);
            $name_user = str_replace("\n","",$record[0]);
            $time = str_replace("\n","",$record[1]);
            if($time != "" && $name_user != ""){
                $this->leaderboard[] = new EntryLeaderboard($name_user, $time);
            }
		}

		fclose($leaderboard_txt);

        $new_leaderboard = array();
        $insert_value = 0;
        if (count($this->leaderboard) < 10) // Time in leaderboard because not enough entries.
        {
            
            if(count($this->leaderboard) == 0)
            {
                $new_leaderboard[] = new EntryLeaderboard($name, time() - $this->start_time);
                $insert_value = 1;
            }
            else
            {

                foreach ($this->leaderboard as &$entry) {
                    if ($insert_value == 0 && $entry->getTime() > time() - $this->start_time) {
                        $new_leaderboard[] = new EntryLeaderboard($name, time() - $this->start_time);
                        $insert_value = 1;
                    }
                    $new_leaderboard[] = $entry;
                }

                if($insert_value == 0)
                {
                    $insert_value = 1;
                    $new_leaderboard[] = new EntryLeaderboard($name, time() - $this->start_time);
                }
            }

        }
        else // Check if the time can hit in the leaderboard.
        {

            foreach ($this->leaderboard as &$entry) {
                if ($insert_value == 0 && intval($entry->getTime()) > time() - $this->start_time) 
                {
                    $insert_value = 1;
                    $new_leaderboard[] = new EntryLeaderboard($name, time() -$this->start_time);
                }
                if (count($new_leaderboard) == 10)
                {
                    break;
                }
                $new_leaderboard[] = $entry;
            }
        }

        $this->leaderboard = $new_leaderboard;
        $this->saveLeaderboard();
        return $insert_value;
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

class EntryLeaderboard {
    private $name;
    private $time;

    public function __construct($name, $time) {
        $this->name = $name;
        $this->time = $time;
    }

    public function serialize() {
        return $this->name.":".strval($this->time);
    }

    public function getTime() {
        return $this->time;
    }	
}

?>
