<?php

session_start();
include 'session_check.php';
include 'db.php';

$logged_in = isset($_SESSION['logged_in']) ? $_SESSION['logged_in'] : false;

if($_SERVER['REQUEST_METHOD'] =="POST")
{
    if(isset($_POST['validate']))
    {
        $sql = "UPDATE Users SET Valid = '1' WHERE Id = '".$_SESSION['Id']."'";
        $result = mysqli_query($conn,$sql);
        if($result)
        {
            header("Location:website/profil.php");
        }
        else{
            echo"doğrulanamadı";
        }
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0", maximum-scale=1.0, user-scalable=no">
    <title>Document</title>
    <link rel="stylesheet" href="giris.css">
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
</head>
<body>

    <!--MENU BAŞLANGIÇ-->
    <header class="header">
        <a href="giris.php" class="logo">BMW</a>
        
<?php $sql = "SELECT Valid FROM Users WHERE Id ='".$_SESSION['Id']."'";
$result = mysqli_query($conn,$sql);
if($result->num_rows >0)
{
if( $row = mysqli_fetch_assoc($result))
{
  if($row['Valid'] == 0)
  {
    echo'   <nav class="navbar">
            <a href="#" style="--i:1;" class="active">AnaSayfa</a>
            <a href="#hakkimizda" style="--i:2;">Hakkımızda</a>
            <a href="modeller.php" style="--i:3;">Modeller</a>
            <a href="#contact-section" style="--i:4;">İletişim</a>
            <button class="btnLogin-popup"onclick="toggleMenu()">Hesabım</button>
            <form method ="post">
            <button type ="submit" class ="btn btn-danger " name ="validate">Doğrula </button>
            </form>
            </nav>';
  }
  else{
    echo '<nav class="navbar">
                <a href="#" style="--i:1;" class="active">AnaSayfa</a>
                <a href="#hakkimizda" style="--i:2;">Hakkımızda</a>
                <a href="modeller.php" style="--i:3;">Modeller</a>
                <a href="#contact-section" style="--i:4;">İletişim</a>
                <button class="btnLogin-popup" onclick="toggleMenu()" >Hesabım</button>
            </nav>';

}
}
}
?>
        



        <div class="social-medya">
            <a href="#"><i class='bx bxl-twitter'></i></a>
            <a href="#"><i class='bx bxl-facebook' ></i></a>
            <a href="#"><i class='bx bxl-instagram' ></i></a>
        </div> 

        <div class="sub-menu-wrap" id="subMenu">
                <div class="sub-menu">
                    <div class="user-info">
                        <h2><?php echo $_SESSION['name'] ?></h2>
                    </div>
                    <hr>

                    <a href="website/profil.php" class="sub-menu-link">
                        <p class="icon"><i class='bx bx-user'></i></p>
                        <p>Profili Düzenle</p>
                        <span>></span>
                    </a>

                    <a href="#contact-section" class="sub-menu-link">
                        <p class="icon"><i class='bx bx-help-circle' ></i></p>
                        <p>Yardım ve Destek</p>
                        <span>></span>
                    </a>

                    <a href="cikis.php" class="sub-menu-link">
                        <p class="icon"><i class='bx bx-log-out' ></i></p>
                        <p>Çıkış</p>
                        <span>></span>
                    </a>
                </div>
            </div>
        </header>
    </header>


<!--ANASAYFA BAŞLANGIÇ-->
    <section class="home">
        <div class="home-content">
            <h1>Son Model Arabalar</h1>
            <h3>Satışta!</h3>
            <p> </p>
            <a href="modeller.php" class="btn">Modelleri görmek için tıkla</a>
        </div>

        <div class="home-img">
            <div class="rhombus">
                <img src="image/car.png" alt="">
            </div>
        </div>

        <div class="rhombus2"></div>
    </section>
<!--ANASAYFA BİTİŞ-->


<!-- HAKKIMIZDA BAŞLANGIÇ-->
<section class="hakkimizda" id="hakkimizda">
    <div class="hakkimizda-content">
        <div class="text-animate">
            <h1>Amacımız Nedir?</h1>
        </div>
        <p>Amacımız kullanıcıların fabrikadan yeni çıkma araçların
            kolay bir şekilde satın alabilmesi, <br>
            galericilerin ise fabrikadan çıkma araçlarını
            kolaylıkla satabilmesidir. <br>
        </p>

        <div class="btn-box">
            <a href="cikis.php" class="ulas">Çıkış Yap</a><br>
            <a href="#contact-section" class="ulas">Görüş/Öneriler </a>
        </div>

        <div class="hakkimizda-imgHover"></div>
    </div>
</section>
<!-- HAKKIMIZDA BİTİŞ-->



<!-- İLETİŞİM BAŞLANGIÇ-->
<section id = "contact-section" class="contact">
    <h2>Öneri/Şikayetler</h2>
    <form method = "POST" action="">
        <div class="iletisim-box">
            <div class="iletisim-field field">
                <input type="text" placeholder="Tam Ad" id="name" class="item" name="fullname" autocomplete="off" required>
                <div class="error-txt">Boş bırakılmamalı</div>
            </div>

            <div class="iletisim-field field">
                <input type="text" placeholder="Email Adresi" id="email" class="item"  name = "mail" autocomplete="off" required>
                <div class="error-txt">Boş bırakılmamalı</div>
            </div>
        </div>

        <div class="iletisim-box">
            <div class="iletisim-field field">
                <input type="text" placeholder="Telefon Numarası" id="phone" class="item"  name ="phonenumber" autocomplete="off" required>
                <div class="error-txt">Boş bırakılmamalı</div>
            </div>

            <div class="iletisim-field field">
                <input type="text" placeholder="konu" id="konu" class="item" name ="subject" au tocomplete="off" required>
                <div class="error-txt">Boş bırakılmamalı</div>
            </div>
        </div>

        <div class="textarea-field field">
            <textarea name="complaint" id="message" cols="30" rows="10" placeholder="Öneri veya Şikayetinizi yazın.(en fazla 250 karakter)" class="item" nautocomplete="off" required></textarea>
            <div class="error-txt">Boş bırakılmamalı</div>
        </div>

        <button name = "message" type="submit">Mesajı Gönder</button>
    </form>
</section>
<?php
if ($_SERVER['REQUEST_METHOD'] == 'POST' && isset($_POST['message'])) {
    $fullname = $_POST['fullname'];
    $email = $_POST['mail'];
    $phonenumber = $_POST['phonenumber'];
    $subject = $_POST['subject'];
    $complaint = $_POST['complaint'];
    $sql = "INSERT INTO Complaints (Name, Email, PhoneNumber, Subject, Message) VALUES ('$fullname', '$email', '$phonenumber', '$subject', '$complaint')";
    if (mysqli_query($conn, $sql)) {
        echo "Mesaj gönderildi";
    } else {
        echo "Mesaj gönderilemedi";
    }
}
?>

<script>
    let subMenu = document.getElementById("subMenu");
    function toggleMenu(){
        subMenu.classList.toggle("open-menu");
    }
</script>
</body>
</html>
