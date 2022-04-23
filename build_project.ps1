<#
    You can run this script locally and just pass the following parameters:
    -projectpath "E:\Projects\bob" 
    -buildpath "E:\Projects\bob\build\Bob.exe" 
    -logpath "E:\Projects\bob\log"
#>

param ($projectpath, $buildpath, $logpath)
write-host "Project Location -> $projectpath"
write-host "Build Location -> $buildpath"
write-host "Logging Location -> $logpath"

& "C:\Program Files\Unity 2020.3.27f1\Editor\Unity.exe" -projectpath $projectpath -buildWindowsPlayer $buildpath -logFile $logpath -quit -batchmode

