using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// ��ʼҳ���UI
/// </summary>
/// 
public class InitUiScript : UIBasePanel
{
    public void StartGame()
    {
        // �л�����  ���صĳ���
        Debug.LogError("change scene");
        SceneManager.LoadScene("LoadScene");
        
    }
    
    public void ContinueGame()
    {
        
        
    } 
    public void ExitGame()
    {
        
        
    }
    

}
