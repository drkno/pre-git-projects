<?php
$sonarr_host = 'http://sonarr';
$sonarr_apik = '';

$days = '7';
if (isset($_GET['days']) && is_numeric($_GET['days'])) {
	$days = $_GET['link'];
}

$requestUntil = date('Y-m-d', strtotime("+$days days")) . 'T00%3A00%3A00.000Z';
$calurl = "$sonarr_host/api/calendar?end=$requestUntil&apikey=$sonarr_apik";

$curl = curl_init($calurl);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, TRUE);
$rawContent = curl_exec($curl);
$contentType = curl_getinfo($curl, CURLINFO_CONTENT_TYPE);
curl_close($curl);

header('Access-Control-Allow-Origin: *');
header("Content-Type: $contentType");
echo $rawContent;
?>
