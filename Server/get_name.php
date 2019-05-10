<?php
require_once "database_connect.php";
$userEmail=$_POST["userEmail"];

$query="SELECT * FROM users WHERE email='$userEmail'";
$result=$conn->query($query);
if($result->num_rows>0)
{
    $user=$result->fetch_assoc();
    echo $user["first_name"]." ".$user["family_name"];
}
$conn->close();



