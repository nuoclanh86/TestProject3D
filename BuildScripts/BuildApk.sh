echo Clearning Up Build Directory
rm -rf ../build/
echo NuocLanh : Starting Build Process
echo NuocLanh : PerformSwitchAndroid
'/c/Program Files/Unity/2020.3.24f1/Editor/Unity.exe' -quit -batchmode -projectPath ../ -executeMethod BuildScripts.PerformSwitchAndroid
# '/Applications/Unity/Hub/Editor/2020.3.24f1/Unity.app/Contents/MacOS/Unity' -quit -batchmode -projectPath ../ -executeMethod BuildScripts.PerformSwitchAndroid
echo NuocLanh : PerformBuildApk
'/c/Program Files/Unity/2020.3.24f1/Editor/Unity.exe' -quit -batchmode -projectPath ../ -executeMethod BuildScripts.PerformBuildApk
# '/Applications/Unity/Hub/Editor/2020.3.24f1/Unity.app/Contents/MacOS/Unity' -quit -batchmode -projectPath ../ -executeMethod BuildScripts.PerformBuildApk
echo NuocLanh : PerformBuild
'/c/Program Files/Unity/2020.3.24f1/Editor/Unity.exe' -quit -batchmode -projectPath ../ -executeMethod BuildScripts.PerformBuild
# '/Applications/Unity/Hub/Editor/2020.3.24f1/Unity.app/Contents/MacOS/Unity' -quit -batchmode -projectPath ../ -executeMethod BuildScripts.PerformBuild
echo NuocLanh : Done