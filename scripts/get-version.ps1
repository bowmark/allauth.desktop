Param(
  [Parameter(Mandatory=$true)]
  [string] $VersionFile
)

$result = Get-Content $VersionFile | Select-String "^Major=([0-9]+)"
$Major = $result[0].Matches.Groups[1].Value

$result = Get-Content $VersionFile | Select-String "^Minor=([0-9]+)"
$Minor = $result[0].Matches.Groups[1].Value

$result = Get-Content $VersionFile | Select-String "^Patch=([0-9]+)"
$Patch = $result[0].Matches.Groups[1].Value

$result = Get-Content $VersionFile | Select-String "^Build=([0-9]+)"
$Build = $result[0].Matches.Groups[1].Value

Write-Host "##teamcity[buildNumber '$Major.$Minor.$Patch.$Build']"
