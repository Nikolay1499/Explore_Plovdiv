<?php
require_once "database_connect.php";
$userEmail=$_POST["userEmail"];
$achievementId=$_POST["achievementId"];

$query="SELECT id FROM users WHERE email='$userEmail'";
$result=$conn->query($query);
if($result->num_rows>0)
{
    $user=$result->fetch_assoc();
    $id=$user["id"];
    $query="SELECT unlocked FROM achievements WHERE number='$achievementId' AND user_id='$id'";
    $result=$conn->query($query);
    $achievement=$result->fetch_assoc();
    if($achievement["unlocked"]==0)
    {
        echo "Постижението не е отключено!";
    }
}
$conn->close();

