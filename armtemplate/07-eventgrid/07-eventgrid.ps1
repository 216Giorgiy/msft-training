Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpneventgrid -Location WestEurope -Force

New-AzureRmResourceGroupDeployment -ResourceGroupName $mpneventgrid -TemplateFile 07-eventgrid.json -endpoint $endpoint

New-AzureRmStorageAccount -ResourceGroupName $mpneventgrid -Location WestEurope -Name eventgridstorage03 -SkuName Standard_LRS