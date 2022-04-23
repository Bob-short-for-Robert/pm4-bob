






<#
    $projectpath  = "path\to\project\folder"
    $buildpath    = "path\to\build.exe"
    $logpath      = "path\to\log.txt"
    "C:\Program Files\Unity\Editor\Unity.exe" -quit -batchmode -projectpath $projectpath -buildWindowsPlayer $buildpath -logFile $logpath
    "C:\Program Files\Unity 2020.3.27f1\Editor\Unity.exe" -quit -batchmode -projectpath $projectpath -buildWindowsPlayer $buildpath -logFile $logpath
    "C:\Program Files\Unity 2020.3.27f1\Editor\Unity.exe" -projectpath $projectpath -buildWindowsPlayer $buildpath -logFile $logpath -quit -batchmode
#>

param ($projectpath, $buildpath, $logpath)
write-host "Project Location -> $projectpath"
write-host "Build Location -> $buildpath"
write-host "Logging Location -> $logpath"

& "C:\Program Files\Unity 2020.3.27f1\Editor\Unity.exe" -projectpath $projectpath -buildWindowsPlayer $buildpath -logFile $logpath -quit -batchmode

