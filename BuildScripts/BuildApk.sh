echo NuocLanh : Starting Build Process
echo NuocLanh : PerformSwitchAndroid
'/c/Program Files/Unity/2020.3.24f1/Editor/Unity.exe' -quit -bachmode -projectPath ../TestProject3D -executeMethod BuildScripts.PerformSwitchAndroid
echo NuocLanh : PerformBuildApk
'/c/Program Files/Unity/2020.3.24f1/Editor/Unity.exe' -quit -bachmode -projectPath ../TestProject3D -executeMethod BuildScripts.PerformBuildApk
echo NuocLanh : Done