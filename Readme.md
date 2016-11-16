#Cmdlet-AssemblyInfo

##Install
Import-Module "..\..\External Tools\CmdletAssemblyInfo\Cmdlet-AssemblyInfo.dll"

##Use
###Search by attribute
<code>
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -AttributeFilter "IncludeSwaggerDocumentation"
</code>

###Search by basetype
<code>
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -BaseTypeFilter "MyBaseType"
</code>

###Search by namespace
<code>
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -Namespace "My.App"
</code>

###Search by namespace
<code>
Get-AssemblyTypes -AssemblyPath "MyAssembly.dll" -FullNameFilter "MyClass"
</code>

