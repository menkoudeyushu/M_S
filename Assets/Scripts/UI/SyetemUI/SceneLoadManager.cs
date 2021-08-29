using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
     
    private string current_scene_name = "";
    private string next_scene_name = "";

    private static SceneLoadManager _sceneloadmanagerinstance;
    
    public static SceneLoadManager SceneLoadManagerInstance
    {
        get
        {
            if (_sceneloadmanagerinstance == null)
                _sceneloadmanagerinstance = new SceneLoadManager();
            return _sceneloadmanagerinstance;
        }
    }

    private SceneLoadManager()
    {
        current_scene_name = "InitScene";
    }

    public string GetNextSceneName()
    {
        return next_scene_name;
    }

    public void SetNextSceneName(string next_name)
    {
        next_scene_name = next_name;

    }

    public void SetCurrentSceneName(string current_name)
    {
        current_scene_name = current_name;
    }
    
    



}
