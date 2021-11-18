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
        $password = $_POST['password'];

        //check if name exists
        $namecheckquery = "SELECT username, hash, salt, wins, losses, score, vip FROM players where username = '" . $username . "';";

        $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

        if(mysqli_num_rows($namecheck) != 1){
                echo "Username or Password Incorrect";
                exit();
        }

        $existinginfo = mysqli_fetch_assoc($namecheck);
        $hash = $existinginfo["hash"];
        $salt = $existinginfo["salt"];

        $loginhash = crypt($password, $salt);
        if($hash != $loginhash){
                echo "6: Incorrect Password";
                exit();
        }

        echo "0\t" . $existinginfo["wins"] . "\t". $existinginfo["losses"] . "\t". $existinginfo["score"] . "\t". $existinginfo["vip"];
        $con->close();
?>