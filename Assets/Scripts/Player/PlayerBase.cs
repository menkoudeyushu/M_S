using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ϊ����ģʽ ��ҵ����ݵļ��� 
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
        /// ��ʼ��������ʱ�� �����е����� ��XML�ļ� ��� ��ǰ����Щ�������
        

    }


    public static PlayerBase GetPlayerBaseInstance()
    {
        // ������ʵ���������򴴽�������ֱ�ӷ���
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
