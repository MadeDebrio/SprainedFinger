<?php
    include('koneksi.php');
    if (isset($_POST['login'])) {//login
        $email = $_POST['email'];// ngambil dari database
        $password = $_POST['password'];
        $sql = mysqli_query($con,"SELECT * FROM user where email = '$email'");
        if ($sql) {
            $result = mysqli_fetch_array($sql);
            if ($password == $result['password']) {
                $_SESSION['id_user'] = $result['id_user'];
                header("Location: index.php ");
            }else {
                echo"<script>alert('Username or password do not match');
                window.location='login.php';</script>";
            }
        }else{
            echo"<script>alert('Username or password not found');
            window.location='login.php';</script>";
        }
    }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.1.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
</head>
<body>
<div class="container my-4">    
    <div  style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
        <div class="panel panel-info">
            <div class="panel-heading">
                <div class="panel-title">Login dan Masuk</div>
            </div>      
            <div style="padding-top:30px" class="panel-body" >              
                <form class="form-horizontal" action="" method="post" role="form">       
                    <div style="margin-bottom: 25px" class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                        <input type="text" class="form-control" name="email" placeholder="email">                                        
                    </div>
                    <div style="margin-bottom: 25px" class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                        <input type="password" class="form-control" name="password" placeholder="password">
                    </div>
                    <center>Apakah Anda Belum Memiliki Akun ? <a href="register_akun.php">Register disini</a></center>
                    <div style="margin-top:10px" class="form-group">
                        <div class="col-sm-12 controls">
                            <input type="submit" name="login" class="btn btn-success" value="Login"/>
                        </div>
                    </div>
                </form>    
            </div>                     
        </div>  
    </div>
</div>
</body>
</html>