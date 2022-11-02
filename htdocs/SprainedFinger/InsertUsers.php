<?php
    //server
    $servername = "localhost";
    $server_username = "root";
    $server_password = "pablo1q2w3e4r";
    $dbName = "sprainedfinger";

    //player
    $username = $_POST["usernamePost"];//"dbee4646";
    $email    = $_POST["emailPost"];//"awikwok";
    $password = $_POST["passwordPost"];//"bl0kgoblok";
    //make connection
    $conn = new mysqli($servername, $server_username, $server_password, $dbName);
    //$conn = mysqli_connect($servername, $username, $password, $dbName);

    //checkconnection
    if (!$conn){
        die("Connection Failed.".mysqli_connect_error());
    }    else echo "Connection Success";
      
      $sql = "INSERT INTO users (USERNAME, EMAIL, PASSWORD) 
              VALUES ('".$username."', '".$email."','".$password."')";
      $result = mysqli_query($conn,$sql);

      if(!$result) echo "there was an error";
      else echo "everything ok";

    
?>