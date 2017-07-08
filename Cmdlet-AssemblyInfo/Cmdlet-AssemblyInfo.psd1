@{
    RootModule = 'Cmdlet-AssemblyInfo.dll'
    ModuleVersion = '1.0.0.0'
    CmdletsToExport = '*'
    GUID = '8cbcb50c-ba04-4553-aa1a-26c1b1ab21fc'
    DotNetFrameworkVersion = '4.5.1'
    Author = 'Emil W'
    Description = 'AssemblyInfo module provides an easy way to extract type information from a .NET assembly'
    CompanyName = 'None'
    Copyright = '(c) 2017 Emil W. All rights reserved.'
    PrivateData = @{
        PSData = @{
            ProjectUri = 'https://github.com/emilw/Cmdlet-AssemblyInfo'
            ReleaseNotes = ''
        }
    }
	RequiredAssemblies = @('Mono.Cecil.dll')
}
