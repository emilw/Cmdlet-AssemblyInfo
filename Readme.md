# Cmdlet-AssemblyInfo
Possible to pick any DLL with or without dependent assemblies and list Types based on different input filters, e.g. Namespace, Attribute, BaseType or FullName.

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
The ```Get-AssemblyTypes``` takes a DLL as input and can list types from within that dll. There exists a set of parameters to filter these out, the different possibilities are listed below.

### Filter by attribute
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -AttributeFilter "IncludeSwaggerDocumentation"
```

### Filter by basetype
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -BaseTypeFilter "MyBaseType"
```

### Filter by namespace
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -Namespace "My.App"
```

### Filter by full name
```powershell
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -FullNameFilter "MyClass"
```

