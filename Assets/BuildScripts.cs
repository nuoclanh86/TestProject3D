using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildScripts : MonoBehaviour
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
}
