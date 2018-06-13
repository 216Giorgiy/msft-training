Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpnavailability -Location WestEurope -Force

New-AzureRmResourceGroupDeployment -ResourceGroupName $mpnavailability -TemplateFile 03-ifavailabilityset.json -adminUsername vmuser -dnsLabelPrefix mpndnsname02 -availabilitySet yes