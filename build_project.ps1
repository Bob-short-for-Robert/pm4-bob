<#
    You can run this script locally and just pass the following parameters:
    -buildTag "local" <-This will be at the end of the Version e.g 0.1.local-home
    -buildpath "E:\Projects\bob\build\Bob.exe"  <-Name and Path of the resultion executable
    -logpath "E:\Projects\bob\log" <-Path for the logfile
    -unitypath "C:\Program Files\Unity 2020.3.27f1\Editor\Unity.exe"  <-Path of your Unity installation
    -increment "build" <-Select between "major", "minor", "build"
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