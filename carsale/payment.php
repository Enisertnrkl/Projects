<?php
session_start();
 include('db.php');
 $getModel = $_GET['model'];
 $sql = "SELECT * FROM Cars WHERE  Model = '$getModel'";
 $result = mysqli_query($conn,$sql);
 while($row = mysqli_fetch_assoc($result))
 {
    $model = $row['Model'];
    $kilometer = $row['Kilometer'];
    $transmission = $row['Transmission'];
    $driveUnit = $row['DriveUnit'];
    $body = $row['Body'];
    $color = $row['Color'];
    $image = $row['Images'];
    $price = $row['Price'];
    $speed = $row['Speed'];
    $_SESSION['carid'] = $row['Id'];
 }


 if($_SERVER['REQUEST_METHOD'] == "POST")
 {
    $user = $_SESSION['Id'];
    $carid = $_SESSION['carid'];
    $cardnumber = $_POST['kart-numara'];
    $expiredate = $_POST['skt'];
    $holdername = $_POST['Ad'];
    $cvc = $_POST['cvc'];
    $sql = "INSERT INTO PurchaseInfo (CarId,CardNumber,CardHolderName,ExpireDate,CVC,UserId) VALUES('$carid','$cardnumber','$holdername','$expiredate','$cvc','$userss')";
    if($result = mysqli_query($conn,$sql))
    {
        echo '<script>alert("Ödeme Başarılı")</script>';
        echo '<script>
        setTimeout(function() {
            window.location.href = "giris.php";
        }, 120);
      </script>';
exit;
    }
    else{
        echo "ÖDEME BAŞARISIZ";
    }
    

 }

 ?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="payment.css">
    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css' rel='stylesheet'>
    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js' rel='stylesheet'>
    <link href='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js' rel='stylesheet'>
    <link href='https://use.fontawesome.com/releases/v5.7.2/css/all.css' rel='stylesheet'>

    <title>Araba Modelleri</title>
</head>
<body>
    

<div class="container">
        <div class="row m-0">
            <div class="col-lg-7 pb-5 pe-lg-5">
                <div class="row">
                    <div class="col-12 p-5">
                        <img src="models/<?php echo $image ?>"
                            alt="">
                    </div>
                    <div class="row m-0 bg-light">
                        <div class="col-md-4 col-6 ps-30 pe-0 my-4">
                            <p class="text-muted">Kilometre</p>
                            <p class="h5"><?php echo $kilometer?><span class="ps-1">km</span></p>
                        </div>
                        <div class="col-md-4 col-6  ps-30 my-4">
                            <p class="text-muted">Hız</p>
                            <p class="h5 m-0"><?php echo $speed?><span class="ps-1">km/h</span></p>
                        </div>
                        <div class="col-md-4 col-6  ps-30 my-4">
                            <p class="text-muted">Vites</p>
                            <p class="h5 m-0"><?php echo $transmission?></p>
                        </div>
                        <div class="col-md-4 col-6 ps-30 my-4">
                            <p class="text-muted">Çekiş</p>
                            <p class="h5 m-0"><?php echo $driveUnit?></p>
                        </div>
                        <div class="col-md-4 col-6 ps-30 my-4">
                            <p class="text-muted">Kasa Tipi</p>
                            <p class="h5 m-0"><?php echo $body?></p>
                        </div>
                        <div class="col-md-4 col-6 ps-30 my-4">
                            <p class="text-muted">Renk</p>
                            <p class="h5 m-0"><?php echo $color?></p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-5 p-0 ps-lg-4">
                <div class="row m-0">
                    <div class="col-12 px-4">
                        <div class="d-flex align-items-end mt-4 mb-2">
                            <p class="h4 m-0"><span class="pe-1"><?php echo $model?></span><span
                                    class="pe-1"></span></p>
                            <P class="ps-3 textmuted"></P>
                        </div>
                        <div class="d-flex justify-content-between mb-2">
                            <p class="textmuted">Miktar</p>
                            <p class="fs-14 fw-bold">1</p>
                        </div>
                        <div class="d-flex justify-content-between mb-2">
                            <p class="textmuted">Ara Toplam</p>
                            <p class="fs-14 fw-bold"><span class="fas fa-lira-sign pe-1"></span><?php echo $price?></p>
                        </div>
                        <div class="d-flex justify-content-between mb-2">
                            <p class="textmuted">Kargo</p>
                            <p class="fs-14 fw-bold">Ücretsiz</p>
                        </div>
                        <div class="d-flex justify-content-between mb-2">
                            <p class="textmuted">Promosyon Kodu</p>
                            <p class="fs-14 fw-bold">-</p>
                        </div>
                        <div class="d-flex justify-content-between mb-3">
                            <p class="textmuted fw-bold">Toplam</p>
                            <div class="d-flex align-text-top ">
                                <span class="fas fa-lira-sign mt-1 pe-1 fs-14 "></span><span class="h4"><?php echo $price?></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 px-0">
                        <div class="row bg-light m-0">
                            <div class="col-12 px-4 my-4">
                                <p class="fw-bold">Ödeme detayları</p>
                            </div>
                            <form method ="POST">
                            <div class="col-12 px-4">
                                <div class="d-flex  mb-4">
                                    <span class="">
                                        <p class="text-muted">Kart numarası</p>
                                        <input class="form-control" name ="kart-numara" type="text"
                                            placeholder="1234 5678 9012 3456" required>
                                    </span>
                                    <div class=" w-100 d-flex flex-column align-items-end">
                                        <p class="text-muted">Son kullanma tarihi</p>
                                        <input class="form-control2" name="skt" type="text"  placeholder="MM/YY" required>
                                    </div>
                                </div>
                                <div class="d-flex mb-5">
                                    <span class="me-5">
                                        <p class="text-muted">Kart sahibinin adı</p>
                                        <input class="form-control" name="Ad" type="text" 
                                            placeholder="Ad" required>
                                    </span>
                                    <div class="w-100 d-flex flex-column align-items-end">
                                        <p class="text-muted">CVC</p>
                                        <input class="form-control3" name="cvc" type="text"  placeholder="XXX" required>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row m-0">
                            <div class="col-12  mb-4 p-0">
                           <button type="submit" class="btn btn-primary">Satın Al<span class="fas fa-arrow-right ps-2"></span></button>
                                </div>
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>