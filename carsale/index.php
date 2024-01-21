<?php
session_start();
include 'db.php';

$logged_in = isset($_SESSION['logged_in']) ? $_SESSION['logged_in'] : false;
 ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0", maximum-scale=1.0, user-scalable=no">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
</head>
<body>

    <!--MENU BAŞLANGIÇ-->
    <header class="header">
        <a href="index.php" class="logo">BMW</a>

        <nav class="navbar">
            <a href="#" style="--i:1;" class="active">AnaSayfa</a>
            <a href="#hakkimizda" style="--i:2;">Hakkımızda</a>
            <a href="#model" style="--i:3;">Modeller</a>
            <a href="#contact-section" style="--i:4;">İletişim</a>
            <button class="btnLogin-popup" >Giriş</button>


        </nav>

        <div class="social-medya">
            <a href="#"><i class='bx bxl-twitter'></i></a>
            <a href="#"><i class='bx bxl-facebook' ></i></a>
            <a href="#"><i class='bx bxl-instagram' ></i></a>
        </div> 
    </header>
<!--MENU BİTİŞ-->


<!--GİRİŞ YAP KISMI BAŞLANGIÇ-->
<?php
if ($_SERVER['REQUEST_METHOD'] == 'POST' && isset($_POST['login'])) {
    $email = $_POST['email'];
    $password = $_POST['password'];
    $sql = "SELECT * FROM Users WHERE Email = '$email' AND Password = '$password'";
    $result = mysqli_query($conn, $sql);
    if ($result->num_rows > 0) {
       
        while($row =  mysqli_fetch_assoc($result))
        {
        $_SESSION['name'] = $row['Name'];
        $_SESSION['Id'] = $row['Id'];
        }
        $_SESSION['email'] = $email;

        $_SESSION['logged_in'] = true;
        header("Location: /site2/giris.php");
        exit();
    } else {
        echo '<script>
            alert("Kullanıcı adı veya şifre yanlış");
        </script>';
    }
}
?>
    <div class="wrapper" id="sade">

        <span class="icon-close">
            <i class='bx bx-x'></i>
        </span>

        <div class="logreg-box">
            <div class="form-box login">
                <div class="logreg-title">
                    <h2>Giriş Yap</h2>
                    <p>Lütfen giriş yapınız.</p>
                </div>

                <form method = "POST">
                    <div class="input-box">
                        <span class="icon"><i class='bx bx-envelope'></i></span>
                        <input type="email" name ="email" required>
                        <label>Email</label>
                    </div>

                    <div class="input-box">
                        <span class="icon"><i class='bx bx-lock-alt' ></i></span>
                        <input type="password" name ="password" required>
                        <label>Şifre</label>
                    </div>

                    <div class="remember-forgot">
                        <label><input type="checkbox">Beni hatırla</label>
                        <a href="#">Şifreni mi unuttun ?</a>
                    </div>

                    <button type="submit" class="buton" name = "login"> Giriş</button>
                    <div class="logreg-link">
                        <p class="ozel">Hesabın yok mu ?
                            <a href="#" class="register-link">Kayıt ol</a>
                        </p>
                    </div>
                </form>
            </div>
            
<!--GİRİŞ YAP KISMI BİTİŞ-->

<!--KAYIT OL KISMI BAŞLANGIÇ-->

<?php
if ($_SERVER['REQUEST_METHOD'] == 'POST' && isset($_POST['register'])) {
    $name = $_POST['name'];
    $username = $_POST['reg_email'];
    $password = $_POST['reg_password'];
    if(isset($_POST['check']))
    {

    $sql = "INSERT INTO Users (Name, Email,Password,Valid) VALUES ('$name', '$username', '$password','false')";
    if (mysqli_query($conn, $sql)) 
    {
        echo "Kullanıcı eklendi";
        header("Location: /site2/index.php");
    } else {
        echo "Veri eklenirken bir sorun oluştu: " . mysqli_error($conn);
    }
}
else{
    echo " Koşulları kabul edin";
}
}
?>
            <div class="form-box register">
                <div class="logreg-title">
                    <h2>Kayıt Ol</h2>
                    <p>Lütfen kayıt olun.</p>
                </div>

                <form action="" method = "POST">
                    <div class="input-box">
                        <span class="icon"><i class='bx bx-user'></i></span>
                        <input type="text" name = "name" required>
                        <label>Ad Soyad</label>
                    </div>

                    <div class="input-box">
                        <span class="icon"><i class='bx bx-envelope'></i></span>
                        <input type="email" name = "reg_email" required>
                        <label>Email</label>
                    </div>

                    <div class="input-box">
                        <span class="icon"><i class='bx bx-lock-alt' ></i></span>
                        <input type="password" name = "reg_password" required>
                        <label>Şifre</label>
                    </div>

                    <div class="remember-forgot">
                        <label><input type="checkbox" name ="check">koşul ve şartları kabul ediyorum.</label>
                    </div>

                    <button type="submit" class="buton" name = "register" > Kayıt Ol</button>
                    <div class="logreg-link">
                        <p class="ozel">Hesabın mı var?
                            <a href="#" class="login-link">Giriş Yap</a>
                        </p>
                    </div>
                </form>
            </div>
        </div>
<!--KAYIT OL KISMI BİTİŞ -->

<!--GOOGLE KISMI BAŞLANGIÇ-->
        <div class="media-options">
            <a href="login.php">
                <i class='bx bxl-google'></i>
                <span> Google ile giriş</span>
            </a>
        </div>
<!--GOOGLE KISMI BAŞLANGIÇ-->
    </div>
<!--GİRİŞ YAP KISMI BİTİŞ-->


<!--ANASAYFA BAŞLANGIÇ-->
    <section class="home">
        <div class="home-content">
            <h1>Son Model Arabalar</h1>
            <h3>Satışta!</h3>
            <p> </p>

            <a href="#" class="btn">Arabaları keşfet.</a>
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
<?php 
?>
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
            <a href="#abc" class="ulas">Giriş yap</a><br>
            <a href="#contact-section" class="ulas">Görüş/Öneriler </a>
        </div>

        <div class="hakkimizda-imgHover"></div>
    </div>
</section>
<!-- HAKKIMIZDA BİTİŞ-->


<!-- MODELLER BAŞLANGIÇ-->
<section class="model" id="model">
    <div class="box-container">
        <div class="box">
            <div class="box-head">
                <img src="models/bmwx5.jpg" alt="model"/>
             <h3><br><br>BMW X5<br><br>
                   SUV
                <h2>Almak için</h2>
            </div>
            <div class="box-bottom">
                <a href="#" class="btn">Giriş Yap</a>
            </div>
        </div>

        <div class="box">
            <div class="box-head">
            <img src="models/bmw7s.jpg" alt="model"/>
                <h3><br><br>BMW 7 Serisi<br><br>
                   Lüks Sedan
                <h2>Almak için</h2>
            </div>
            <div class="box-bottom">
                <a href="#" class="btn">Giriş Yap</a>
            </div>
        </div>

        <div class="box">
            <div class="box-head">
            <img src="models/bmwm4.jpg" alt="model"/>
                <h3><br><br>BMW M4<br><br>
                  Spor Araba
                <h2>Almak için</h2>
            </div>
            <div class="box-bottom">
                <a href="#sade" class="btn">Giriş Yap</a>
            </div>
        </div>
    </div>


</section>
<!--MODELLER BİTİŞ-->


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
<script src="script.js"></script>
</body>
</html>
