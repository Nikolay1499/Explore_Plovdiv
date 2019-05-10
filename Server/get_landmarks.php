<?php
require_once "database_connect.php";
$userEmail=$_POST["userEmail"];

$query="SELECT id FROM users WHERE email='$userEmail'";
$result=$conn->query($query);
if($result->num_rows>0)
{
    $user=$result->fetch_assoc();
    $id=$user["id"];
    
    $query="SELECT visited FROM landmarks WHERE user_id='$id'";
    $result=$conn->query($query);
    $count=0;
    $visited=0;
    while($landmark=$result->fetch_assoc())
    {
        if($landmark["visited"]!=0)
        {
            $visited++;
        }
        $count++;
    }
    echo $visited."/".$count;
}
$conn->close();
