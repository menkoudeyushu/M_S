using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System;
using DaiMangou.Storyteller;

public class IconAssignmentPostProcessor : AssetPostprocessor
{
    // Called when Editor Starts
    static IconAssignmentPostProcessor()
    {
        prepareSettingsDir();
        reloadAllToolIcons();
    }

    private static string settingsPath = Application.dataPath + "/Storyteller/Resources/ToolIconSettings.text";

    private static bool firstRun = true;


    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {


        prepareSettingsDir();

        //Load old settings 
        ToolIconSaver savedToolIconSaver = LoadSettings();


        //   Texture2D icon = Resources.Load("Assets/Storyteller/Resources/ToolImageData/TextFile.png") as Texture2D;

        for (int j = 0; j < importedAssets.Length; j++)
        {
            string asset = importedAssets[j];

            MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(asset);
            if (script != null)
            {
                if (script.name == "Interaction")
                {
                    //  ApplyIcon(script, InteractionIcon);  
                    IconManager.SetIcon(script, ImageLibrary.Interaction);
                    processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
                }

                if (script.name == "CollisionInteractionReceiver")
                {
                    IconManager.SetIcon(script, ImageLibrary.CollisionReceiver);
                    processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
                }

                if (script.name == "CollisionInteractionTrigger")
                {
                    IconManager.SetIcon(script, ImageLibrary.CollisionTrigger);
                    processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
                }
                if (script.name == "ClickListener")
                {
                    IconManager.SetIcon(script, ImageLibrary.ClickListener);
                    processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
                }
                if (script.name == "InteractableCharacter")
                {
                    IconManager.SetIcon(script, ImageLibrary.InteractableCharacter);
                    processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
                }
                if (script.name == "InteractionTriggerManager")
                {
                    IconManager.SetIcon(script, ImageLibrary.InteractionTriggerManager);
                    processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
                }


            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }


    public static string pathToGUID(string path)
    {
        return AssetDatabase.AssetPathToGUID(path);
    }

    public static string guidToPath(string guid)
    {
        return AssetDatabase.GUIDToAssetPath(guid);
    }

    public static void processToolIcon(ToolIconSaver oldSettings, string scriptPath, string scriptGUID)
    {
        int matchIndex = -1;

        if (oldSettings == null)
        {
            oldSettings = new ToolIconSaver();
        }

        if (oldSettings.toolIconData == null)
        {
            oldSettings.toolIconData = new List<ToolIconData>();
        }

        ToolIconData toolIconData = new ToolIconData();
        toolIconData.scriptPath = scriptPath;
        toolIconData.scriptGUID = scriptGUID;

        //Check if this guid exist in the List already. If so, override it with the match index
        if (containsGUID(oldSettings, scriptGUID, out matchIndex))
        {
            oldSettings.toolIconData[matchIndex] = toolIconData;
        }
        else
        {
            //Does not exist, add it to the existing one
            oldSettings.toolIconData.Add(toolIconData);
        }

        //Save the data
        SaveSettings(oldSettings);

        //If asset does not exist, delete it from the json settings
        for (int i = 0; i < oldSettings.toolIconData.Count; i++)
        {
            if (!assetExist(scriptPath))
            {
                //Remove it from the List then save the modified List
                oldSettings.toolIconData.RemoveAt(i);
                SaveSettings(oldSettings);
              //  Debug.Log("Asset " + scriptPath + " no longer exist. Deleted it from JSON Settings");
                continue; //Continue to the next Settings in the List
            }
        }
    }

    //Re-loads all the tool icons
    public static void reloadAllToolIcons()
    {
        if (!firstRun)
        {
            firstRun = false;
            return; //Exit if this is not first run
        }

        //Load old settings 
        ToolIconSaver savedToolIconSaver = LoadSettings();

        if (savedToolIconSaver == null || savedToolIconSaver.toolIconData == null)
        {
         //   Debug.Log("No Previous Tool Icon Settings Found!");
            return;//Exit
        }


            //Apply Icon Changes
            for (int i = 0; i < savedToolIconSaver.toolIconData.Count; i++)
        {
            string asset = savedToolIconSaver.toolIconData[i].scriptPath;

            //If asset does not exist, delete it from the json settings
            if (!assetExist(asset))
            {
                //Remove it from the List then save the modified List
                savedToolIconSaver.toolIconData.RemoveAt(i);
                SaveSettings(savedToolIconSaver);
               // Debug.Log("Asset " + asset + " no longer exist. Deleted it from JSON Settings");
                continue; //Continue to the next Settings in the List
            }


      
            MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(asset);
            if (script == null)
            {
                continue;
            }
            if (script.name == "Interaction")
            {
                //  ApplyIcon(script, InteractionIcon);  
                IconManager.SetIcon(script, ImageLibrary.Interaction);
                processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
            }

            if (script.name == "CollisionInteractionReceiver")
            {
                IconManager.SetIcon(script, ImageLibrary.CollisionReceiver);
                processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
            }

            if (script.name == "CollisionInteractionTrigger")
            {
                IconManager.SetIcon(script, ImageLibrary.CollisionTrigger);
                processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
            }
            if (script.name == "ClickListener")
            {
                IconManager.SetIcon(script, ImageLibrary.ClickListener);
                processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
            }
            if (script.name == "InteractableCharacter")
            {
                IconManager.SetIcon(script, ImageLibrary.InteractableCharacter);
                processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
            }
            if (script.name == "InteractionTriggerManager")
            {
                IconManager.SetIcon(script, ImageLibrary.InteractionTriggerManager);
                processToolIcon(savedToolIconSaver, asset, pathToGUID(asset));
            }

        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private static void ApplyIcon(MonoScript script, Texture2D icon)
    {
        PropertyInfo inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
        SerializedObject serializedObject = new SerializedObject(script);
        inspectorModeInfo.SetValue(serializedObject, InspectorMode.Debug, null);
        SerializedProperty iconProperty = serializedObject.FindProperty("m_Icon");
        iconProperty.objectReferenceValue = icon;
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
        EditorUtility.SetDirty(script);
     //   Debug.Log("Applied Tool Icon to: " + script.name);
    }

    //Creates the Settings File if it does not exit yet
    private static void prepareSettingsDir()
    {
        if (!File.Exists(settingsPath))
        {
            File.Create(settingsPath);
        }
    }

    public static void SaveSettings(ToolIconSaver toolIconSaver)
    {
        try
        {
            string jsonData = JsonUtility.ToJson(toolIconSaver, true);
           // Debug.Log("Data: " + jsonData);

            byte[] jsonByte = Encoding.ASCII.GetBytes(jsonData);
            File.WriteAllBytes(settingsPath, jsonByte);
        }
        catch (Exception e)
        {
            Debug.Log("Settings not Saved: " + e.Message);
        }
    }

    public static ToolIconSaver LoadSettings()
    {
        ToolIconSaver loadedData = null;
        try
        {
            byte[] jsonByte = File.ReadAllBytes(settingsPath);
            string jsonData = Encoding.ASCII.GetString(jsonByte);
            loadedData = JsonUtility.FromJson<ToolIconSaver>(jsonData);
            return loadedData;
        }
        catch (Exception e)
        {
            Debug.Log("No Settings Loaded: " + e.Message);
        }
        return loadedData;
    }

    public static bool containsGUID(ToolIconSaver toolIconSaver, string guid, out int matchIndex)
    {
        matchIndex = -1;

        if (toolIconSaver == null || toolIconSaver.toolIconData == null)
        {
          //  Debug.Log("List is null");
            return false;
        }

        for (int i = 0; i < toolIconSaver.toolIconData.Count; i++)
        {
            if (toolIconSaver.toolIconData[i].scriptGUID == guid)
            {
                matchIndex = i;
                return true;
            }
        }
        return false;
    }

    public static bool assetExist(string path)
    {
        return File.Exists(path);
    }

    [Serializable]
    public class ToolIconSaver
    {
        public List<ToolIconData> toolIconData;
    }

    [Serializable]
    public class ToolIconData
    {
        public string scriptPath;
        public string scriptGUID;
    }
}