Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpnaks -Location WestEurope -Force

New-AzureRmResourceGroupDeployment -ResourceGroupName $mpnaks -TemplateFile 10-akscluster.json -TemplateParameterFile 10-akscluster.parameters.json
