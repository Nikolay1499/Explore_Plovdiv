<?php
require_once "database_connect.php";
$userEmail=$_POST["userEmail"];
$colourId=$_POST["colourId"];

$query="UPDATE users SET colour_id='$colourId' WHERE email='$userEmail'";
$result=$conn->query($query);
$conn->close();

