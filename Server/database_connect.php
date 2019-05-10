<?php

$servername = "localhost";
$username =  "id4955199_ivo993";
$password = "123456789";
$dbName = "id4955199_explore_plovdiv";
    
$conn = new mysqli($servername, $username, $password, $dbName);
if(!$conn)
{
    die("Connection Failed. ". mysqli_connect_error());
}
$conn->set_charset('utf8');