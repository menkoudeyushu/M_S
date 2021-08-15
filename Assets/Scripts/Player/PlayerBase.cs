using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 此类为单例模式 玩家的数据的集合 
// Singleton
public class PlayerBase : MonoBehaviour
{
    
    
    
    private static PlayerBase PlayerInstance;
    private int PlayerMaxHealth;
    private int PlayerCurrentHealth;
    private int PlayerMaxMagic;
    private int PlayerCurrentMagic;

    private PlayerBase()
    {
        /// 初始化这个类的时候 ，所有的数据 读XML文件 算出 当前的这些玩家属性
        

    }


    public static PlayerBase GetPlayerBaseInstance()
    {
        // 如果类的实例不存在则创建，否则直接返回
        if (PlayerInstance == null)
        {
            PlayerInstance = new PlayerBase();
        }
        return PlayerInstance;
    }

    private void OnDestroy()
    {
        PlayerInstance = null;
    }
}
