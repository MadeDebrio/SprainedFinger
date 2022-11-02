<?php
	session_start();
	$con = mysqli_connect("localhost","root","","beli_buku");

	if(! $con) {
	die('Koneksi gagal: ' . mysqli_error());
   }
?>