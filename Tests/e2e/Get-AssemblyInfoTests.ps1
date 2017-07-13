
Write-Host "Starting e2e tests"
$testFailed

function ReportTestResult($testName, $expected, $actual){
	if($expected -notmatch $actual){
		$testFailed = 1
		Write-Host -ForeGroundColor Red "Test: $testName failed. Expected: $expected vs. Actual: $actual"
	} else{
		Write-Host -ForeGroundColor Green "Test: $testName is ok"
	}
}

$modulePath = Join-Path $PSScriptRoot ..\bin\Debug\Cmdlet-AssemblyInfo.dll
Write-Host "Module path is $modulePath"

Import-Module $modulePath

$testAssemblyPath = Join-Path $PSScriptRoot ..\bin\Debug\Tests.dll
Write-Host "Test assembly path is $modulePath"

Get-AssemblyTypes -AssemblyPath $testAssemblyPath

$result = Get-AssemblyTypes -AssemblyPath $testAssemblyPath
ReportTestResult "Empty filter parameter" 8 $result.length


$result = Get-AssemblyTypes -AssemblyPath $testAssemblyPath -Attribute "Tests.Mock.DummyAttribute"
ReportTestResult "Attribute filter test" 2 $result.length

if($testFailed){
	Write-Host -ForegroundColor Red "The e2e tests failed on one or more places"
	return 1
} else
{
	Write-Host -ForegroundColor Green "E2E tests was performed without errors"
}