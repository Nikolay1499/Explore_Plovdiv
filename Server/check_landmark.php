<?php
require_once "database_connect.php";
$userEmail=$_POST["userEmail"];
$landmarkId=$_POST["landmarkId"];

$query="SELECT id FROM users WHERE email='$userEmail'";
$result=$conn->query($query);
if($result->num_rows>0)
{
    $user=$result->fetch_assoc();
    $id=$user["id"];
    $query="SELECT visited FROM landmarks WHERE number='$landmarkId' AND user_id='$id'";
    $result=$conn->query($query);
    $landmark=$result->fetch_assoc();
    if($landmark["visited"]==0)
    {
        echo "Забележителността не е посетена!";
    }
}
$conn->close();



