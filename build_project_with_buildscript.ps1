<#
    You can run this script locally and just pass the following parameters:
    -projectpath "E:\Projects\bob" 
    -buildpath "E:\Projects\bob\build\Bob.exe" 
    -logpath "E:\Projects\bob\log"
#>

param ($buildTag, $buildpath, $logpath, $increment, $unityPath)
write-host "Build Location -> $buildpath"
write-host "Logging Location -> $logpath"
write-host "Build Tag -> $buildTag"
write-host "Product Increment -> $increment"

[Environment]::SetEnvironmentVariable('INCREMENT',$increment)
[Environment]::SetEnvironmentVariable('BUILD_TAG',$buildTag)
[Environment]::SetEnvironmentVariable('BUILD_PATH',$buildpath)

& $unityPath -executeMethod Editor.BuildScript.Windows -logFile $logpath -quit -batchmode

Get-Content -Path $logpath -Wait

