Write-Host "Starting e2e tests"
$testFailed

$modulePath = Join-Path $PSScriptRoot ..\bin\Debug\Cmdlet-AssemblyInfo.dll
Write-Host "Module path is $modulePath"

Import-Module $modulePath

$testAssemblyPath = "..\bin\Debug\Tests.dll"

Get-AssemblyTypes -AssemblyPath $testAssemblyPath

$result = Get-AssemblyTypes -AssemblyPath $testAssemblyPath

if($result.length -notmatch 8){
    $testFailed = 1
}

$result = Get-AssemblyTypes -AssemblyPath $testAssemblyPath -Namespace "Test.Mock.DummyAttribute"

if($result.length -notmatch 2){
    $testFailed = 1
}

if($testFailed){
	Write-Host -ForegroundColor Red "The e2e tests failed on one or more places"
	return 1
} else
{
	Write-Host -ForegroundColor Green "E2E tests was performed without errors"
}