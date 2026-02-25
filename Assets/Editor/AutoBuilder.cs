using System.Linq;
using UnityEditor;
using UnityEngine;

namespace _Source.Editor
{
    public static class AutoBuilder
    {
        private static string[] GetEnabledScenes()
        {
            return 
                EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).ToArray();
        }

        [MenuItem("Build/Build PC")]
        public static void BuildPC()
        {
            Debug.Log("Начинается сборка для ПК (Windows 64)...");
        
            BuildPlayerOptions options = new BuildPlayerOptions
            {
                scenes = GetEnabledScenes(),
                locationPathName = "Builds/PC/Game.exe",
                target = BuildTarget.StandaloneWindows64,
                options = BuildOptions.None
            };
        
            BuildPipeline.BuildPlayer(options);
            Debug.Log("Сборка для ПК завершена! Путь: Builds/PC/");
        }

        [MenuItem("Build/Build Android")]
        public static void BuildAndroid()
        {
            Debug.Log("Начинается сборка для Android...");
        
            BuildPlayerOptions options = new BuildPlayerOptions
            {
                scenes = GetEnabledScenes(),
                locationPathName = "Builds/Android/Game.apk",
                target = BuildTarget.Android,
                options = BuildOptions.None
            };
        
            BuildPipeline.BuildPlayer(options);
            Debug.Log("Сборка для Android завершена! Путь: Builds/Android/");
        }

        [MenuItem("Build/Build All")]
        public static void BuildAll()
        {
            Debug.Log("Запуск полной сборки (ПК + Android)");
            BuildPC();
            BuildAndroid();
        
            Debug.Log("Полная сборка успешно завершена!");
        }
    }
}