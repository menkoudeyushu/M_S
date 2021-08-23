using System.IO;
using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace tools
{
    public static class PrefabCacheUtil
    {
        static Dictionary<string, GameObject> PrefabsMap;
        static List<string> keepList;
        
        static PrefabCacheUtil() 
        {
            prefabsMap = new Dictionary<string, GameObject>();
            keepList = new List<string>();
        }

        public static T GetAssetsFromMapWithT<T>(string path) where T : Object
        {
            T prefab = null;
            string prefabPathTemp = "";
            // 初始的路径prefab路径
            string init_prefabs_path = "path";
            prefabPathTemp = init_prefabs_path + ".prefab";
            
            prefab = AssetDatabase.LoadAssetAtPath<T>(prefabPathTemp);
            
            if(prefab == null) 
            {
                Debug.LogError("GetAssetsFromMapWithT not found", prefabPathTemp);
            }
        }
        
        public static GameObject GetPrefabFromMap(string path) {
            if (path.Length <= 0)
            {
                return null;
            }
            if (prefabsMap.ContainsKey(path)) {
                return prefabsMap[path];
            } 
            else 
            {
                GameObject prefab = GetAssetsFromMapWithT<GameObject>(path);
                if (prefab != null) {
                    prefabsMap[path] = prefab;
                }
                return prefab;
            }
        }
        
        // 此方法为返回单个的prefabs
        public static GameOject GetPrefabByPath(string path)
        {
            string[] files = Directory.GetFiles(path, "*.prefab", SearchOption.AllDirectories);
            if (files.Length >= 2)
            {
                // 这因该是不可能的
                Debug.LogError("prefab重复命名");
            }

            if (files.Length == 1)
            {
                GameObject _prefab = AssetDatabase.LoadAssetAtPath(files[0], typeof(GameObject)) as GameObject;
                return _prefab;

            }
        }


        
        
        
    }
}