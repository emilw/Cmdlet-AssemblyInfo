#Cmdlet-AssemblyInfo

##Install
Import-Module "..\..\External Tools\CmdletAssemblyInfo\Cmdlet-AssemblyInfo.dll"

##Use
###Search by attribute
<code>
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -Attribute "IncludeSwaggerDocumentation"
</code>

###Search by basetype
<code>
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -BaseType "MyBaseType"
</code>

###Search by namespace
<code>
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -Namespace "My.App"
</code>
