$mpn = "1fd221fd-5347-47fa-9fd6-fb4fa7f31251"
$mct = "4fed9d46-5a51-4344-9dd2-ad97ed9fbc09"
$mpngroup = "mpn-rg-arm" 
$mctgroup = "mct-rg-arm" 


#Select "MPN" subscription + create RG
Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpngroup -Location WestEurope -Force

#Select "MCT" subscription + create RG
Select-AzureRmSubscription -SubscriptionId $mct
New-AzureRmResourceGroup -Name $mctgroup -Location WestEurope -Force

#Select "MPN" subscription + create deployment
Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroupDeployment -ResourceGroupName $mpngroup -TemplateFile 01-crosssubscriptiondeployments.json -StorageAccountName1 mpnstoragearm01 -StorageAccountName2 mctstoragearm01 -CrossSubscription $mct -CrossResourceGroup $mctgroup

#Get storage account in MPN Group
(Get-AzureRmStorageAccount -ResourceGroupName $mpngroup).Id

#Get storage account in MCT Group
Select-AzureRmSubscription -SubscriptionId $mct
(Get-AzureRmStorageAccount -ResourceGroupName $mctgroup).Id
