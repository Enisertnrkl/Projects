<?php
include('C:\xampp\htdocs\site\db.php');
session_start();

$sql="SELECT * FROM users WHERE Email= '".$_SESSION['email']."'";
$result = mysqli_query($conn,$sql);
if($result-> num_rows > 0)
{
while($row = mysqli_fetch_assoc($result))
{
    $name=$row['Name'];
    $email =$row['Email'];
    $password = $row['Password'];
    $username = $row['UserName'];
    $biography=$row['Biography'];
    $dateofbirth=$row['DateOfBirth'];
    $country=$row['Country'];
    $phonenumber=$row['PhoneNumber'];
    $website=$row['Website'];
    $twitter=$row['Twitter'];
    $facebook=$row['Facebook'];
    $google=$row['Google'];
    $linkedin=$row['LinkedIn'];
    $instagram=$row['Instagram'];
    $company=$row['Company'];
    $valid = $row['Valid'];

}
}

?>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Profil</title>
    <link rel="stylesheet" href="profil.css">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/css/bootstrap.min.css" rel="stylesheet">
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
</head>

<body>
    <div class="container light-style flex-grow-1 container-p-y">
        <h4 class="font-weight-bold py-3 mb-4">
            Profil Ayarları
        </h4>
        <div class="card overflow-hidden">
            <div class="row no-gutters row-bordered row-border-light">
                <!--MENU KISMI BAŞLANGIÇ-->
                <div class="col-md-3 pt-0">
                    <div class="list-group list-group-flush account-settings-links">
                        <a class="list-group-item list-group-item-action active" data-toggle="list"
                            href="#account-general">Genel</a>
                        <a class="list-group-item list-group-item-action" data-toggle="list"
                            href="#account-change-password">Şifreyi Değiştir</a>
                        <a class="list-group-item list-group-item-action" data-toggle="list"
                            href="#account-info">Bilgi</a>
                        <a class="list-group-item list-group-item-action" data-toggle="list"
                            href="#account-social-links">Sosyal Medya Adresi</a>
                        <a class="list-group-item list-group-item-action" data-toggle="list"
                            href="#account-connections">Bağlantılarınız</a>
                        <a class="list-group-item list-group-item-action" data-toggle="list"
                            href="#account-notifications">Bildirimler</a>
                    </div>
                </div>
                <!--MENU KISMI BİTİŞ-->


                <div class="col-md-9">
                    <div class="tab-content">
                        <div class="tab-pane fade active show" id="account-general">
                            <div class="card-body media align-items-center">
                                <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt
                                    class="d-block ui-w-80">

                                <!--FOTOĞRAF KISMI BAŞLANGIÇ-->
                                <div class="media-body ml-4">
                                    <label class="btn btn-outline-primary">
                                        Yeni fotoğraf yükle
                                        <input type="file" class="account-settings-fileinput">
                                    </label> &nbsp;
                                    <button type="button" class="btn btn-default md-btn-flat">Sıfırla</button>
                                    <div class="text-light small mt-1">İzin verilen uzantılar; JPG, GIF or PNG. Maksimum büyüklük 800K</div>
                                </div>
                                <!--FOTOĞRAF KISMI BİTİŞ-->

                            </div>
                            <hr class="border-light m-0">
                            <!--GENEL KISMI BAŞLANGIÇ-->
                            <?php if($_SERVER['REQUEST_METHOD']=="POST")
                            {
                                if(isset($_POST['saveChangesGenel']))
                                {
                                    $namee=$_POST['name'];
                                    $emaill =$_POST['email'];
                                    $usernamee = $_POST['username'];
                                    $companyy=$_POST['company'];
                                    $sql = "SELECT Email FROM Users WHERE Email = '$emaill'";
                                    $sql2= "UPDATE Users SET Username='$usernamee',Name='$namee',Email='$emaill',Company='$companyy' WHERE Email='".$_SESSION['email']."'";
                                    $result = mysqli_query($conn,$sql);
                                    if($result -> num_rows == 0 || $emaill == $email )
                                    {
                                    $result2 = mysqli_query($conn,$sql2);
                                    if($result2)
                                    {
                                        $_SESSION['name'] = $namee;
                                        $_SESSION['email'] = $emaill;
                                        header('Location: profil.php');
                                    }
                                    }
                                else
                                {
                                    echo"bu email zaten mevcut.";
                                }
                                }
                                elseif(isset($_POST['saveChangesPassword']))
                                {
                                    $oldpw = $_POST['oldpw'];
                                    $newpw = $_POST['newpw'];
                                    $validation = $_POST['validation'];
                                    $sql= "SELECT Password FROM Users WHERE Email='".$_SESSION['email']."'";
                                    $result=mysqli_query($conn,$sql);
                                    if($result->num_rows >0)
                                    {
                                        if($row = mysqli_fetch_assoc($result))
                                        {
                        
                                            $oldpwcheck=$row['Password'];

                                            if($oldpw == $oldpwcheck)
                                            {
                                                if($newpw == $validation)
                                                {
                                                    $sql = "UPDATE Users SET Password = '$newpw' WHERE Email ='".$_SESSION['email']."'";
                                                    $result = mysqli_query($conn,$sql);
                                                    
                                                        if($result)
                                                        {
                                                            header('Location: profil.php');
                                                        }
                                                }
                                                else
                                                {
                                                echo "şifreler uyuşmuyor";
                                                }
                                            }
                                            else
                                            {
                                                echo "mevcut şifre yanlış";
                                            }
                                        }
                                    }
                                }
                                        


                                elseif(isset($_POST['saveChangesInformation']))
                                {
                                    $biographyinfo = $_POST['biography'];
                                    $dateofbirthinfo = $_POST['dateofbirth'];
                                    $countryinfo = $_POST['country'];
                                    $phonenumberinfo = $_POST['phonenumber'];
                                    $websiteinfo = $_POST['website'];
                                    $sql = "UPDATE Users SET Biography = '$biographyinfo', DateOfBirth='$dateofbirthinfo',Country ='$countryinfo',PhoneNumber='$phonenumberinfo',Website='$websiteinfo' WHERE Email ='".$_SESSION['email']."'";
                                    $result = mysqli_query($conn,$sql);
                                    if($result)
                                    {
                                       
                                        header('Location: profil.php');
                                    }
                                    else{
                                        echo "bir şeyler ters gitti";
                                    }


                                }
                                elseif(isset($_POST['saveChangesSocials']))
                                {
                                    $twitterinfo = $_POST['twitter'];
                                    $facebookinfo = $_POST['facebook'];
                                    $googleinfo = $_POST['google'];
                                    $linkedininfo = $_POST['linkedin'];
                                    $instagraminfo = $_POST['instagram'];
                                    $sql ="UPDATE Users SET Twitter = '$twitterinfo',Facebook = '$facebookinfo',Google = '$googleinfo',LinkedIn='$linkedininfo',Instagram='$instagraminfo' WHERE Email='".$_SESSION['email']."'";
                                    $result = mysqli_query($conn,$sql);
                                    if($result)
                                    {
                                        header('Location: profil.php');
                                    }
                                    else{
                                        echo "bir şeyler ters gitti";
                                    }

                                    

                                }
    
                            } ?>
                            <div class="card-body">
                                <div class="form-group">
                                    <form method="post">
                                    <label class="form-label">Kullanıcı Adı</label>
                                    <input type="text" class="form-control mb-1" name = "username" value="<?php echo"$username" ?>">
                                </div>
                                <div class="form-group">
                                    <label class="form-label">İsim</label>
                                    <input type="text" class="form-control" name = "name" value ="<?php echo"$name"?>">
                                </div>
                                <div class="form-group">
                                    <label class="form-label">E-mail</label>
                                    <input type="text" class="form-control mb-1" name = "email" value ="<?php echo"$email"?>">
                                    <?php 
                                    if($valid == false)
                                    {
                                    echo'<div class="alert alert-warning mt-3">
                                        E-postanız onaylanmadı. Lütfen gelen kutunuzu kontrol edin.<br>
                                    </div>';
                                    }
                                    else{
                                        echo'<div class="alert-success mt-3">
                                        E-postanız onaylandı!<br>
                                        <br>
                                    </div>';
                                    }
                                    ?>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Şirket</label>
                                    <input type="text" class="form-control"  name="company" value="<?php  echo"$company" ?>" >
                                    <div class="text-right mt-3">
                                <button type="submit" class="btn btn-primary" name="saveChangesGenel">Değişiklikleri Kaydet</button>&nbsp;
</form>
                                    </div>

                                </div>
                            </div>
                           
                            <!--GENEL KISMI BİTİŞ-->


                        </div>
                        <!--ŞİFRE DEĞİŞTİR KISMI BAŞLANGIÇ-->
                        <div class="tab-pane fade" id="account-change-password">
                            <div class="card-body pb-2">
                                <div class="form-group">
                                    <form method="post" action="profil.php">
                                    <label class="form-label">Mevcut Şifre</label>
                                    <input type="password"  class="form-control" name ="oldpw" required>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Yeni Şifre</label>
                                    <input type="password"  class="form-control" name ="newpw" required>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Yeni Şifreyi Tekrar Yaz</label>
                                    <input type="password"  class="form-control" name = "validation" required>
                                    <div class="text-right mt-3">
                                    <button type="submit" class="btn btn-primary" name="saveChangesPassword">Değişiklikleri Kaydet</button>&nbsp;
                                    </div>
</form>
                                </div>
                           
                            </div>
                        </div>
                        <!--ŞİFRE DEĞİŞTİR KISMI BİTİŞ-->

                        <!--BİLGİ KISMI BAŞLANGIÇ-->
                        <div class="tab-pane fade" id="account-info">
                            <div class="card-body pb-2">
                                <div class="form-group">
                                    <form method="post">
                                    <label class="form-label">Biografi</label>
                                    <textarea class="form-control"  rows="5" name="biography"><?php echo $biography; ?></textarea>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Doğum Tarihi</label>
                                    <input type="text" name="dateofbirth" class="form-control" value="<?php  echo"$dateofbirth" ?>"  placeholder="yyyy-mm-dd">
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Ülke</label>
                                    <select class="custom-select" name="country">
                                        <?php 
                                        $countries = array("USA","Türkiye","UK","Almanya","Fransa");
                                        
                                        echo "<option selected>$country</option>";

                                        foreach($countries as $c)
                                        {
                                            if($c != $country)
                                            {
                                                echo "<option>$c</option>";
                                            }   
                                        }
                                        
                                        ?>
                                    </select>
                                </div>
                            </div>
                            <hr class="border-light m-0">
                            <div class="card-body pb-2">
                                <h6 class="mb-4">Bağlantılar</h6>
                                <div class="form-group">
                                    <label class="form-label">Telefon Numarası</label>
                                    <input type="text" class="form-control" name="phonenumber" value = <?php echo"$phonenumber"  ?> >
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Website</label>
                                    <input type="text" class="form-control"  name="website" value= <?php echo"$website"  ?>>
                                    <div class="text-right mt-3">
                                    <button type="submit" class="btn btn-primary" name="saveChangesInformation">Değişiklikleri Kaydet</button>&nbsp;
                                    </div>
</form>
                                </div>
                            </div>
                        </div>
                        <!--BİLGİ KISMI BİTİŞ-->

                        <!--SOSYAL MEDYA KISMI BAŞLANGIÇ-->
                        <div class="tab-pane fade" id="account-social-links">
                            <div class="card-body pb-2">
                                <div class="form-group">
                                    <form method="post">
                                    <label class="form-label">Twitter</label>
                                    <input type="text" class="form-control" name="twitter" value= <?php  echo"$twitter" ?> >
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Facebook</label>
                                    <input type="text" class="form-control" name="facebook" value= <?php  echo"$facebook" ?>>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Google+</label>
                                    <input type="text" class="form-control" name="google" value= <?php  echo"$google" ?>>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">LinkedIn</label>
                                    <input type="text" class="form-control" name="linkedin" value= <?php  echo"$linkedin" ?>>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Instagram</label>
                                    <input type="text" class="form-control" name="instagram" value= <?php  echo"$instagram" ?>>
                                    <div class="text-right mt-3">
                                    <button type="submit" class="btn btn-primary" name="saveChangesSocials">Değişiklikleri Kaydet</button>&nbsp;
                                    </div>
</form>
                                </div>
                            </div>
                        </div>
                        <!--SOSYAL MEDYA KISMI BİTİŞ-->

                        <!--BAĞLANTILARINIZ KISMI BAŞLANGIÇ-->
                        <div class="tab-pane fade" id="account-connections">
                            <div class="card-body">
                                <button type="button" class="btn btn-twitter">Bağlandı ->
                                    <strong>Twitter</strong></button>
                            </div>
                            <hr class="border-light m-0">
                            <div class="card-body">
                                <h5 class="mb-2">
                                    <a href="javascript:void(0)" class="float-right text-muted text-tiny"><i
                                            class="ion ion-md-close"></i> Sil</a>
                                    <i class="ion ion-logo-google text-google"></i>
                                    Google hesabını bağla:
                                </h5>
                                
                            </div>
                            <hr class="border-light m-0">
                            <div class="card-body">
                                <button type="button" class="btn btn-facebook">Bağlandı ->
                                    <strong>Facebook</strong></button>
                            </div>
                            <hr class="border-light m-0">
                            <div class="card-body">
                                <button type="button" class="btn btn-instagram">Bağlandı ->
                                    <strong>Instagram</strong></button>
                            </div>
                        </div>
                        <!--BAĞLANTILARINIZ KISMI BİTİŞ-->

                        <!--BİLDİRİMLER KISMI BAŞLANGIÇ-->
                        <div class="tab-pane fade" id="account-notifications">
                            <div class="card-body pb-2">
                                <h6 class="mb-4">Aktivasyon</h6>
                                <div class="form-group">
                                    <label class="switcher">
                                        <input type="checkbox" class="switcher-input" checked>
                                        <span class="switcher-indicator">
                                            <span class="switcher-yes"></span>
                                            <span class="switcher-no"></span>
                                        </span>
                                        <span class="switcher-label">Birisi gönderime yorum yaptığında e-posta gönderilsin.</span>
                                    </label>
                                </div>
                                <div class="form-group">
                                    <label class="switcher">
                                        <input type="checkbox" class="switcher-input" checked>
                                        <span class="switcher-indicator">
                                            <span class="switcher-yes"></span>
                                            <span class="switcher-no"></span>
                                        </span>
                                        <span class="switcher-label">Birisi formuma yanıt verdiğinde bana e-posta gönderilsin.</span>
                                    </label>
                                </div>
                                <div class="form-group">
                                    <label class="switcher">
                                        <input type="checkbox" class="switcher-input">
                                        <span class="switcher-indicator">
                                            <span class="switcher-yes"></span>
                                            <span class="switcher-no"></span>
                                        </span>
                                        <span class="switcher-label">Birisi beni takip ettiğinde e-posta gönderilsin.</span>
                                    </label>
                                </div>
                            </div>
                            <hr class="border-light m-0">
                            <div class="card-body pb-2">
                                <h6 class="mb-4">Talep</h6>
                                <div class="form-group">
                                    <label class="switcher">
                                        <input type="checkbox" class="switcher-input" checked>
                                        <span class="switcher-indicator">
                                            <span class="switcher-yes"></span>
                                            <span class="switcher-no"></span>
                                        </span>
                                        <span class="switcher-label">Haber ve Duyurular</span>
                                    </label>
                                </div>
                                <div class="form-group">
                                    <label class="switcher">
                                        <input type="checkbox" class="switcher-input">
                                        <span class="switcher-indicator">
                                            <span class="switcher-yes"></span>
                                            <span class="switcher-no"></span>
                                        </span>
                                        <span class="switcher-label">Haftalık güncellemeler</span>
                                    </label>
                                </div>
                                <div class="form-group">
                                    <label class="switcher">
                                        <input type="checkbox" class="switcher-input" checked>
                                        <span class="switcher-indicator">
                                            <span class="switcher-yes"></span>
                                            <span class="switcher-no"></span>
                                        </span>
                                        <span class="switcher-label" >Aylık Özet</span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <!--BİLDİRİMLER KISMI BİTİŞ-->
                    </div>
                </div>
            </div>
        </div>
        <div class="text-right mt-3">                
            <a href="/site2/giris.php"><buttontype="button" class="btn btn-default">İptal Et</button></a>
        </div>
    </div>
    <script data-cfasync="false" src="/cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript">

    </script>
</body>

</html>