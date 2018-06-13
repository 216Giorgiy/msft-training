Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpnwebreference -Location WestEurope -Force

New-AzureRmResourceGroupDeployment -ResourceGroupName $mpnwebreference -TemplateFile 09-resourcereference.json -TemplateParameterFile 09-resourcereference.parameters.json
