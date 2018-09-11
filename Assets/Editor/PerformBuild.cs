using UnityEditor;
class PerformBuild
{
    static void Build()
    {
        string[] scenes = { "Assets/Scenes/SampleScene.unity" };

        //just adding comment to trigger build ....
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = "AndroidTestBuild",
            target = BuildTarget.Android,
            options = BuildOptions.None
		};

		BuildPipeline.BuildPlayer(buildPlayerOptions);
		
    }
}
