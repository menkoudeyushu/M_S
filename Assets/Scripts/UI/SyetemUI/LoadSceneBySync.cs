using System;
using System.Collections;
using System.Collections.Generic;
using tools;
using Tools;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadSceneBySync : MonoBehaviour
{
   
    // 滑动条  
    public Slider processBar;

    public Image BackGround;
    
    // Application.LoadLevelAsync()这个方法的返回值类型是AsyncOperation  
    private AsyncOperation async;
    
    // 当前进度，控制滑动条的百分比  
    private uint nowprocess = 0;
    [SerializeField]
    Text process_text;

    private string next_scene_name;

    // private Image background_pic;
    void Start()
    {
        
        next_scene_name = SceneLoadManager.SceneLoadManagerInstance.GetNextSceneName();
        // 不同的scene_name 就换不同的 图片
        GetSceneBackgroundImage(next_scene_name);
        // 开启一个协程  
        StartCoroutine(loadScene());
    }

    public void GetSceneBackgroundImage(string scene_name)
    {
        string image_path = Application.dataPath + @"/Resources/UiImage" + scene_name;
        // 村子的BG
        BackGround.sprite = StaticToolClass.GetImageByPath(image_path);
    }
    
    // 定义一个协程  
    IEnumerator loadScene()
    {
        // 异步读取场景  
        // 指定需要加载的场景名  
        //async = Application.LoadLevelAsync("需要加载的场景名字或者index");

        async= SceneManager.LoadSceneAsync(next_scene_name);
        // 设置加载完成后不能自动跳转场景  
        async.allowSceneActivation = false;

        // 下载完成后返回async  
        yield return async;

    }

    private void Update()
    {
        if (async == null)
        {
            // 如果没加载完，就跳出update方法，不继续执行return下面的代码  
            return;
        }
        
        uint toProcess;
        
        if (async.progress < 0.9f)
        {
            //  进度值  
            toProcess = (uint)(async.progress * 100);
        }
        else
        {
            toProcess = 100;
        }
        if (nowprocess < toProcess)
        {
            // 当前滑动条的进度加一  
            nowprocess++;
        }

        processBar.value = nowprocess / 100f;
        process_text .text= nowprocess.ToString() + "%";
        
        if (nowprocess == 100)
        {
            // 设置为true的时候，如果场景数据加载完毕，就可以自动跳转场景  
            async.allowSceneActivation = true;
        }
        
        

    }
    
    
    
    
    
    
    
}
