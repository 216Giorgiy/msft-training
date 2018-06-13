Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpnmsilinux -Location WestEurope -Force

$deployment = New-AzureRmResourceGroupDeployment -ResourceGroupName $mpnmsilinux -TemplateFile 05-msilinuxtoarm.json -adminUsername "vmadmin"
$deployment
$deployment.Outputs.commandToLogin.Value