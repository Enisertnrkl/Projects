<?php
include('db.php');
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="model.css">
    <title>Araba Modelleri</title>
</head>
<body>

<!--MENU BAŞLANGIÇ-->
<header class="header">
    <a href="#" class="logo">BMW</a>
    
        <nav class="navbar">
            <a href="giris.php" style="--i:1;" class="active">AnaSayfa</a>
            <a href="giris.php#hakkimizda" style="--i:2;">Hakkımızda</a>
            <a href="modeller.php" style="--i:3;">Modeller</a>
            <a href="giris.php#contact-section" style="--i:4;">İletişim</a>
        </nav>
    
        <div  class="social-medya" >
            <a href="#"><i class='bx bxl-twitter'></i></a>
            <a href="#"><i class='bx bxl-facebook' ></i></a>
            <a href="#"><i class='bx bxl-instagram' ></i></a>
         </div> 

        
</header>

<!-- MODELLER BAŞLANGIÇ-->
<section class="model" id="model">
    <div class="box-container">
    <?php
$sql = "SELECT Model,Description,Images FROM Cars";
$result = mysqli_query($conn,$sql);
while( $row = mysqli_fetch_assoc($result))
{
    $model = $row['Model'];
    $description = $row['Description'];
    $imageFileName = $row['Images'];

       echo' <div class="box">
            <div class="box-head">
                <img src="models/'.$imageFileName.'" alt="model"/>
             <h3><br><br>'.$model.'<br><br>
                   '.$description.'
            </div>

            <div class="box-bottom">
                <a href="payment.php?model='.$model.'" class="btn">Satın Al</a>
            </div>
        </div>';
}
        ?>
    </div>
</section>
<!--MODELLER BİTİŞ-->
</body>
</html>
