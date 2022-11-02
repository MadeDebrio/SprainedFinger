<?php
    $servername = "localhost";
    $username = "root";
    $password = "pablo1q2w3e4r";
    $dbName = "sprainedfinger";

    //make connection
    $conn = new mysqli($servername, $username, $password, $dbName);
    //$conn = mysqli_connect($servername, $username, $password, $dbName);

    //checkconnection
    if (!$conn){
        die("Connection Failed.".mysqli_connect_error());
    }    else echo "Connection Success";
      
      $sql = "SELECT ID, NICKNAME, HS, ACC FROM leaderboard ORDER BY HS";
      $result = mysqli_query($conn,$sql);

      
      
      if(mysqli_num_rows($result)>0){
        //show data each row
        while($row = mysqli_fetch_assoc($result)){
            echo "<br>"."ID: ".$row['ID'] . "\t|NICKNAME: ".$row['NICKNAME'] . "\t|HIGHSCORE: ".$row['HS'] . "\t|ACCURACY: ".$row['ACC']  ;
        }
      }

    
?>