<!-- veritabanı bağlantısı-->
<?php 
	$servername = "localhost";
	$username   = "root";
	$password   = "";
	$database   = "satis_sitesi";
	$conn       = new mysqli($servername, $username, $password, $database);
	if (!$conn) {
		die("Veritabanı bağlantısı başarısız: " . mysqli_connect_error());
	}
	?>
