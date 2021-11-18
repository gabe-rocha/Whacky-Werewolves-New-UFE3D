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
	$namecheckquery = "SELECT username FROM players where username = '" . $username . "';";

	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

	if(mysqli_num_rows($namecheck) > 0){
		echo "3: Username already exists";
		exit();
	}

	//add user to table
	$salt = "\$5\$rounds=5000\$" . "whackywolves" . $username . "\$";
	$hash = crypt($password, $salt);

	$insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";

	mysqli_query($con, $insertuserquery) or die("4: Insert Player Query Error");

	echo("0");
	$con->close();
?>
