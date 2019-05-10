<?php
require_once "database_connect.php";
$userEmail=$_POST["userEmail"];

$query="SELECT id FROM users WHERE email='$userEmail'";
$result=$conn->query($query);
if($result->num_rows>0)
{
    $user=$result->fetch_assoc();
    $id=$user["id"];
    
    $query="SELECT unlocked FROM achievements WHERE user_id='$id'";
    $result=$conn->query($query);
    $count=0;
    $unlocked=0;
    while($achievement=$result->fetch_assoc())
    {
        if($achievement["unlocked"]!=0)
        {
            $unlocked++;
        }
        $count++;
    }
    echo $unlocked."/".$count;
}
$conn->close();

