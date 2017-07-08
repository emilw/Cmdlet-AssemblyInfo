	Write-Host "Starting creation of module structure"

	$files = "Cmdlet-AssemblyInfo.dll","Cmdlet-AssemblyInfo.psd1","Mono.Cecil.dll"

	if(Test-Path Cmdlet-AssemblyInfo){

	foreach($file in $files){
		Remove-Item Cmdlet-AssemblyInfo\$file
		Write-Host "Removed $file"
	}
	}else{
		New-Item -ItemType directory -Path Cmdlet-AssemblyInfo
	}

	Get-ChildItem -Path Cmdlet-AssemblyInfo
	Write-Host "Should be empty"
	
	foreach($file in $files){
		Copy-Item $file Cmdlet-AssemblyInfo\$file
		Write-Host "$file copied"
	}

	Get-ChildItem -Path Cmdlet-AssemblyInfo

	Test-ModuleManifest -Path Cmdlet-AssemblyInfo\Cmdlet-AssemblyInfo.psd1

	Write-Host "Done creating module structure"
