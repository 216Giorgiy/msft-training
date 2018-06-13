Select-AzureRmSubscription -SubscriptionId $mpn
Register-AzureRmResourceProvider -ProviderNamespace Microsoft.Solutions

New-AzureRmResourceGroup -Name $mpnapplications -Location WestEurope

$storageAccount = New-AzureRmStorageAccount -ResourceGroupName $mpnapplications -Name "mpnapplicationstorage05" -Location WestEurope -SkuName Standard_LRS -Kind Storage
$ctx = $storageAccount.Context

New-AzureStorageContainer -Name appcontainer -Context $ctx -Permission blob
Set-AzureStorageBlobContent -File "app\ubuntuManagedApp.zip" -Container appcontainer -Blob "ubuntuManagedApp.zip" -Context $ctx 


$ownerID=(Get-AzureRmRoleDefinition -Name Owner).Id

$blob = Get-AzureStorageBlob -Container appcontainer -Blob "ubuntuManagedApp.zip" -Context $ctx
$authorization = $appowner + ":" + $ownerID

New-AzureRmManagedApplicationDefinition -Name "mpnmanagedubuntu" -Location "westeurope" -ResourceGroupName $mpnapplications -LockLevel ReadOnly -DisplayName "Managed Ubuntu App" -Description "Managed Ubunty App" -Authorization $authorization  -PackageFileUri $blob.ICloudBlob.StorageUri.PrimaryUri.AbsoluteUri

