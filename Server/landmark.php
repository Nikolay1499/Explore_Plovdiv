<?php
    require_once "database_connect.php";
	$email=$_POST["email"];
	$id=$_POST["id"];
	$sql_query="SELECT id FROM users WHERE email='$email'";
	$result = mysqli_query($conn, $sql_query);
	if(mysqli_num_rows($result) > 0 ){
	$row = mysqli_fetch_assoc($result); 
	$user_id =  $row['id'];
	$sql = "UPDATE landmarks SET visited='1' WHERE user_id='".$user_id."' AND number='".$id."'";
	$result = mysqli_query($conn ,$sql);
        $conn->close();
	}
	