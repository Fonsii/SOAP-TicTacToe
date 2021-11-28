<?php

require_once 'TicTacToe.class.php';
ini_set('soap.wsdl_cache_enabled', '0');
ini_set('soap.wsdl_cache_ttl', '0'); 
 
if (isset($_GET['wsdl'])) {
	header('Content-Type: application/soap+xml; charset=utf-8');
	echo file_get_contents('TicTacToe.wsdl');
}
else {
	session_start();
	$servidorSoap = new SoapServer('http://localhost/TicTacToe-RPC-Encoded/?wsdl');

	//Para evitar la excepción por defecto de SOAP PHP cuando no existe HTTP_RAW_POST_DATA,
	//se regresa explícitamente el siguiente fallo cuando no hay solicitud (v.b. desde un navegador)

	$servidorSoap->setClass('TicTacToe');
	$servidorSoap->setPersistence(SOAP_PERSISTENCE_SESSION);
	$servidorSoap->handle();
}

?>
