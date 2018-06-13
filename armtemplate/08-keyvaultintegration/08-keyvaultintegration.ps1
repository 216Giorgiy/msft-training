Select-AzureRmSubscription -SubscriptionId $mpn
New-AzureRmResourceGroup -Name $mpnkeyvault -Location FranceCentral -Force

$password = "K3yV@ult"
$vaultname = "mpnkeyvault01"
$secretname = "sqladminpassword"

New-AzureRmKeyVault -VaultName $vaultname -ResourceGroupName $mpnkeyvault -Location FranceCentral -EnabledForTemplateDeployment

$secretvalue = ConvertTo-SecureString $password -AsPlainText -Force

Set-AzureKeyVaultSecret -VaultName $vaultname -Name $secretname -SecretValue $secretvalue

New-AzureRmResourceGroupDeployment -ResourceGroupName $mpnkeyvault -TemplateFile 08-keyvaultintegration.json -TemplateParameterFile 08-keyvaultintegration.parameters.json
