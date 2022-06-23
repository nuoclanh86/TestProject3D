using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildScripts
{
    public static void PerformBuildApk()
    {
        string[] defaultScene = { "Assets/Scenes/MainScene.unity" };
        BuildPipeline.BuildPlayer(defaultScene, ".build/game.apk",
            BuildTarget.Android, BuildOptions.None);
    }

    public static void PerformSwitchAndroid()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
    }

	public static void PerformBuild ()
	{
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = new[] { "Assets/Scene1.unity", "Assets/Scene2.unity" };
		BuildPipeline.BuildPlayer(buildPlayerOptions);
	}
	
	public static void PerformSwitchIos()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);
    }
	
	public static void PerformBuildXcodeProject ()
	{
		string[] defaultScene = { "Assets/Scenes/MainScene.unity" };
		BuildPipeline.BuildPlayer(defaultScene, "build/ios/xcode", BuildTarget.iOS, BuildOptions.Development);
	}
}
