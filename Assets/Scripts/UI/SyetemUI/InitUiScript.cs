using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 起始页面的UI
/// </summary>
/// 
public class InitUiScript : UIBasePanel
{
    public void StartGame()
    {
        // 切换场景  加载的场景
        SceneManager.LoadScene("LoadScene");
        
    }
    
    public void ContinueGame()
    {
        
        
    } 
    public void ExitGame()
    {
        
        
    }
    

}
