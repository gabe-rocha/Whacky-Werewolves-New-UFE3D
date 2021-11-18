<?php

        $host="ww-db-instance.czpbr19xa7o9.us-east-2.rds.amazonaws.com";
        $port=3306;
        $socket="";
        $user="master_wolf";
        $password="3352jack";
        $dbname="whacky-werewolves";

        $con = new mysqli($host, $user, $password, $dbname, $port, $socket) or die ('Could not connect to the database server' . mysqli_connect_error());

        //check that connection happened
        if(mysqli_connect_errno()){
                echo "1: Connection failed";
                exit();
        }
        
        $username = $_POST['username'];
        $wins = $_POST['wins'];
        $losses = $_POST['losses'];
        $score = $_POST['score'];

        $updateleaderboardquery = "UPDATE players SET wins = " . $wins . ", losses = " . $losses . ", score = " . $score . "  WHERE username = '" . $username . "';";

        mysqli_query($con, $updateleaderboardquery) or die ("Error updating leaderboard");
        echo "0";

        $con->close();
?>