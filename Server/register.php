<?php

require_once "database_connect.php";
$firstName=$_POST["firstName"];
$familyName=$_POST["familyName"];
$email=$_POST["email"];
$password=$_POST["password"];
$password=password_hash($password, PASSWORD_DEFAULT);
$landmarksCount=$_POST["landmarksCount"];
$achievementsCount=$_POST["achievementsCount"];

$query="SELECT email FROM users WHERE email='$email'";
$result=$conn->query($query);
if($result->num_rows==0)
{
    $query="INSERT INTO users(first_name,family_name,email,password, colour_id) VALUES('$firstName','$familyName','$email','$password','0')";
    $result=$conn->query($query);
    $userId=$conn->insert_id;
    for($i=0;$i<$landmarksCount;$i++)
    {
        $query="INSERT INTO landmarks(number, user_id, visited) VALUES('$i', '$userId', 0)";
        $result=$conn->query($query);
    }
    for($i=0;$i<$achievementsCount;$i++)
    {
        $query="INSERT INTO achievements(number, user_id, unlocked) VALUES('$i', '$userId', 0)";
        $result=$conn->query($query);
    }
}
 else
 {
     echo "Имейлът вече е зает!";
 }
$conn->close();
