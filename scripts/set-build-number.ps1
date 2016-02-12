Param(
  [Parameter(Mandatory=$true)]
  [string] $VersionFile,
  [Parameter(Mandatory=$true)]
  [string] $BuildCount
)

(Get-Content $VersionFile) -replace "^Build=([0-9]+)", "Build=$BuildCount" | Set-Content $VersionFile
