<?php
/* kullanıcının giriş yapıp yapmadığını kontrol eder. */
if (!isset($_SESSION['logged_in']) || $_SESSION['logged_in'] !== true) {
    echo "bu sayfaya erişiminiz yok.";
    exit;
}
?>