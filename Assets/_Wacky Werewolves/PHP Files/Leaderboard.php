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

        $leaderboardquery = "SELECT username, wins, losses, score FROM players ORDER BY score DESC, wins DESC LIMIT 999;";

        $result = mysqli_fetch_all($con->query($leaderboardquery), MYSQLI_ASSOC) or die("2: Leaderboard query failed");
        foreach($result as $rows){
                foreach($rows as $field){
                        echo "$field\t";
                }
        }
        $con->close();
?>