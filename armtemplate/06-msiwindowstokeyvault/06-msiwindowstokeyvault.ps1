Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpnmsiwindows -Location WestEurope -Force

$deployment = New-AzureRmResourceGroupDeployment -ResourceGroupName $mpnmsiwindows -TemplateFile 06-msiwindowstokeyvault.json -adminUsername "vmadmin"
$deployment
$deployment.Outputs.powerShellCommandToGetKeyVaultSecret.Value
