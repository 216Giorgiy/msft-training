New-AzureRmResourceGroup -Name $mpnappstorage -Location WestEurope

$storageAccount = New-AzureRmStorageAccount -ResourceGroupName $mpnappstorage -Name "mpnappstorage01" -Location WestEurope -SkuName Standard_LRS -Kind Storage
$ctx = $storageAccount.Context

New-AzureStorageContainer -Name appcontainer -Context $ctx -Permission blob

Set-AzureStorageBlobContent -File "app\ubuntuManagedApp.zip" -Container appcontainer -Blob "ubuntuManagedApp.zip" -Context $ctx 