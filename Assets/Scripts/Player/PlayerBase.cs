using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
// Singleton
    public class PlayerBase : MonoBehaviour
    {
        // 这个静态的类有什么属性以后在顶
        private static PlayerBase PlayerInstance;
        private int PlayerMaxHealth;
        private int PlayerCurrentHealth;
        public static int PlayerMaxMagic;
        private int PlayerCurrentMagic;
        
        // 构造函数
        private PlayerBase()
        {
            // 在构造函数中 读取XML文件的数据

        }
        
        // 用不用属性来控制private的变量?
        
        
        //todo:
        public static void GetPlayerDataByXML()
        {
            
            
        }


        public static PlayerBase GetPlayerBaseInstance()
        {
            if (PlayerInstance == null)
            {
                PlayerInstance = new PlayerBase();
            }
            return PlayerInstance;
        }

        private void OnDestroy()
        {
            
            Debug.LogError("static playerbase class delete");
            PlayerInstance = null;
        }
        
    }
}
