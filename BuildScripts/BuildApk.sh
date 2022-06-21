echo Clearning Up Build Directory
rm -rf ../build/
echo NuocLanh : Starting Build Process
echo NuocLanh : PerformSwitchAndroid
'/c/Program Files/Unity/2020.3.24f1/Editor/Unity.exe' -quit -bachmode -projectPath ../ -executeMethod BuildScripts.PerformSwitchAndroid
echo NuocLanh : PerformBuildApk
'/c/Program Files/Unity/2020.3.24f1/Editor/Unity.exe' -quit -bachmode -projectPath ../ -executeMethod BuildScripts.PerformBuildApk
echo NuocLanh : Done