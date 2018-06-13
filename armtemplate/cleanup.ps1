Select-AzureRmSubscription -SubscriptionId $mpn
Remove-AzureRmResourceGroup -Name $mpngroup -Force
Remove-AzureRmResourceGroup -Name $mpngroupnics -Force
Remove-AzureRmResourceGroup -Name $mpnavailability -Force
Remove-AzureRmResourceGroup -Name $mpnapplications -Force
Remove-AzureRmResourceGroup -Name $mpnmsilinux -Force
Remove-AzureRmResourceGroup -Name $mpnmsiwindows -Force
Remove-AzureRmResourceGroup -Name $mpneventgrid -Force
Remove-AzureRmResourceGroup -Name $mpnkeyvault -Force



Select-AzureRmSubscription -SubscriptionId $mct
Remove-AzureRmResourceGroup -Name $mctgroup -Force
