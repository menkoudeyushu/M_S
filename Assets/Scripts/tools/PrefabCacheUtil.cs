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
        // 这个dictionary只是为缓存的储存，
        static Dictionary<string, GameObject> PrefabsMap;
        static List<string> keepList;
        
        static PrefabCacheUtil() 
        {
            prefabsMap = new Dictionary<string, GameObject>();
            keepList = new List<string>();
        }

        //
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
                return null;
            }

            if (files.Length == 1)
            {
                GameObject _prefab = AssetDatabase.LoadAssetAtPath(files[0], typeof(GameObject)) as GameObject;
                return _prefab;

            }
        }
        
        public static GameObject CreateObjectFromPrefabPathWithParent(string path, Transform parent = null) {
            GameObject prefab = PrefabCacheUtil.GetPrefabFromMap(path);
            if (prefab == null) {
                LogMgr.LogError("error prefab not exists", path);
                return GameObject.CreatePrimitive(PrimitiveType.Cube);
            }
            GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent, false) as GameObject;
            return gameObject;
        }
        
        public static GameObject CreateObjectFromPrefabPath(string path, Transform parent = null) {
            return CreateObjectFromPrefabPathWithPosition(path, Vector3.zero, parent);
        }
        
        public static GameObject CreateObjectFromPrefabPathWithPosition(string path, Vector3 defaultPosition, Transform parent) {
            GameObject prefab = PrefabCacheUtil.GetPrefabFromMap(path);
            if (prefab == null) {
                LogMgr.LogError("error prefab not exists", path);
                return GameObject.CreatePrimitive(PrimitiveType.Cube);
            }
            GameObject gameObject = UnityEngine.Object.Instantiate(prefab, defaultPosition, Quaternion.identity, parent) as GameObject;
            return gameObject;
        }

        public static bool IsAssetsExist(string path)
        {
            Object o = GetAssetsFromMapWithT<Object>(path);
            if(o == null)
            {
                return false;
            }
            return true;
        }

        
        
        
    }
}