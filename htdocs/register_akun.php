<?php
 function connection() {
    $dbServer = 'localhost';
    $dbUser = 'root';
    $dbPass = '';
    $dbName = "beli_buku";
 
    $conn = mysqli_connect($dbServer, $dbUser, $dbPass);
 
    mysqli_select_db($conn,$dbName);
     
    return $conn;
 }
?>

<?php
$status = '';
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
  $nama_user = $_POST['nama_user'];
  $email = $_POST['email'];
  $password_ = $_POST['password_'];
  $status_ = 2;
  $query = "INSERT INTO user (nama_user,email,password,status ) VALUES('$nama_user','$email','$password_','$status_')"; 

    //eksekusi query
    $result = mysqli_query(connection(),$query);
    if ($result) {
      $status = 'ok';
    }
    else{
      $status = 'err';
    }
}
?>
   <style type="text/css">
      * {
        font-family: "Trebuchet MS";
      }
      h1 {
        text-transform: uppercase;
        color: grey;
      }
    button {
          background-color: grey;
          color: #fff;
          padding: 10px;
          text-decoration: none;
          font-size: 12px;
          border: 0px;
          margin-top: 20px;
    }
    label {
      margin-top: 10px;
      float: left;
      text-align: left;
      width: 100%;
    }
    input {
      padding: 6px;
      width: 100%;
      box-sizing: border-box;
      background: #f8f8f8;
      border: 2px solid #ccc;
      outline-color: grey;
    }
    div {
      width: 100%;
      height: auto;
    }
    .base {
      width: 400px;
      height: auto;
      padding: 20px;
      margin-left: auto;
      margin-right: auto;
      background: #ededed;
    }
    .mb-2{
      margin-bottom:10px;
    }
    </style>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>

<?php 
              if ($status=='ok') {
                echo "<script>alert('Berhasil Mendaftar,Silahkan Login!.');window.location='login.php';</script>";
            }
              elseif($status=='err'){
                echo '<br><br><div class="alert alert-danger" role="alert">Coba lagi</div>';
              }
           ?>

<form action="register_akun.php" method="POST">
<section class="base">
<h1 style="text-align: center">register</h1>
    <div class="tambahdata">
        <label>nama</label>
    <input type="text" class="tambahdata" placeholder="nama" name="nama_user" required="required">
    <label>email</label>
    <input type="text" class="tambahdata" placeholder="email" name="email" required="required">
    <label>password</label>
    <input type="password" class="tambahdata mb-2" placeholder="password_" name="password_" required="required">
    <center>Sudah Punya Akun ? <a href="login.php">Login disini</a></center>
    <button type="submit" class="btn btn-primary">Simpan</button>

    </section>



    </div>

</body>
</html>