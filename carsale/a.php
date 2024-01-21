<?php 
include('db.php');
 $sql = "SELECT * FROM PurchaseInfo";
 $result = mysqli_query($conn,$sql);
 while($row = mysqli_fetch_assoc($result))
 {
    echo 'CarId :'. $row['CarId'].'   Card Number: '.$row['CardNumber'].'   Card Holder Name : '.$row['CardHolderName'].'   Card Expire Date : '.$row['ExpireDate'].'<br>  ';
 }
?>