using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
public class AutoSave : EditorWindow
{
    private bool autoSaveScene = true;
    private bool showMessage = true;
    private bool isStarted = false;
    private int intervalScene = 2;
    private DateTime lastSaveTimeScene;
    private string projectPath;
    private Scene sceneName;

    private void OnEnable()
    {
        projectPath = Application.dataPath;
        lastSaveTimeScene = DateTime.Now;
    }

    [MenuItem("Custom/AutoSave")]
    public static void Init()
    {
        EditorWindow.GetWindow(typeof(AutoSave));
    }

    void OnGUI()
    {
        // GUILayout.BeginVertical();

        GUILayout.Space(10);
        GUILayout.Label("Info:", EditorStyles.boldLabel);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Saving to:", "" + projectPath);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Saving scene:", "" + sceneName);

        GUILayout.Space(10);
        GUILayout.Label("Options:", EditorStyles.boldLabel);

        GUILayout.Space(10);
        autoSaveScene = EditorGUILayout.BeginToggleGroup("Auto save", autoSaveScene);

        GUILayout.Space(10);
        intervalScene = EditorGUILayout.IntSlider("Interval (minutes)", intervalScene, 1, 10);


        if (isStarted)
        {
            EditorGUILayout.LabelField("Last save:", "" + lastSaveTimeScene);
        }
        EditorGUILayout.EndToggleGroup();
        showMessage = EditorGUILayout.BeginToggleGroup("Show Message", showMessage);
        EditorGUILayout.EndToggleGroup();
    }
    void Update()
    {
        sceneName = EditorSceneManager.GetActiveScene();
        if (autoSaveScene)
        {
            if (DateTime.Now.Minute >= (lastSaveTimeScene.Minute + intervalScene) || DateTime.Now.Minute == 59 && DateTime.Now.Second == 59)
            {
                saveScene();
            }
        }
        else
        {
            isStarted = false;
        }
    }
    void saveScene()
    {
        lastSaveTimeScene = DateTime.Now;
        EditorSceneManager.SaveScene(sceneName);
        isStarted = true;
        if (showMessage)
        {
            Debug.Log("AutoSave saved: " + sceneName.name + " on " + lastSaveTimeScene);
        }
        AutoSave repaintSaveWindow = (AutoSave)EditorWindow.GetWindow(typeof(AutoSave));
        repaintSaveWindow.Repaint();
    }
}
