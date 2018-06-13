Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpngroupnics -Location WestEurope -Force

New-AzureRmResourceGroupDeployment -ResourceGroupName $mpngroupnics -TemplateFile 02-copysamplenics.json -storageAccountName mpnstrcopynics01 -adminUsername vmuser -dnsNameforLBIP mpndnsname01 -vmSize Standard_D2_v2 -nicCount 2

