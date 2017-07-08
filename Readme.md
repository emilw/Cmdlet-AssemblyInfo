# Cmdlet-AssemblyInfo

## Install
### Through PowershellGet
[More information here](https://www.powershellgallery.com/packages/Cmdlet-AssemblyInfo)
```powershell
Install-Module -Name Cmdlet-AssemblyInfo 
```

### From release
[Get the zip package here](https://github.com/emilw/Cmdlet-AssemblyInfo/releases)
```powershell
Import-Module "..\..\External Tools\CmdletAssemblyInfo\Cmdlet-AssemblyInfo.dll"
```

## Use
### Search by attribute
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -AttributeFilter "IncludeSwaggerDocumentation"
```

### Search by basetype
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -BaseTypeFilter "MyBaseType"
```

### Search by namespace
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -Namespace "My.App"
```

### Search by namespace
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -FullNameFilter "MyClass"
```

