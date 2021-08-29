using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using System.IO;
using ServerGuilt;
public class UIManager
{

    // 构造函数
    private UIManager()//【单例模式】构造方法为私有，UIManager的实例仅能在类内构造
    {
        //自动解析Json文件并赋值给panelList
        //并使用prefab文件夹下的信息对panelList进行更新,再写入json文件
        UIPanelInfoSaveInJson();
    }


    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UIManager();
            return _instance;
        }
    }

    private Transform canvasTransform;
    public Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
                //通过名称获取Canvas上的Transform，所以不要有同名Canvas
                canvasTransform = GameObject.Find("Canvas").transform;
            return canvasTransform;
        }
    }


    // 全部UI的prefab路径
    readonly string panelPrefabPath = Application.dataPath + @"/Resources/Prefabs/UI";
    readonly string jsonPath = Application.streamingAssetsPath + @"/player_data/Json/UIType.json";

    //数据
    private List<UIPanel> panelList;
    //private Dictionary<string, string> panelPathDict;
    private Dictionary<EnumClass.UIPanelType, UIBasePanel> panelDict;

    public List<UIPanel> ReadJsonFile(string jsonPath)
    {
        //如果找不到UIJson文件，则新建一个Json文件并写入“[]”
        //如果仅新建一个空Json文件，Json转换会返回一个null，也就是后面的list等于null，之后使用list的操作就会报一个空指针错误。
        if (!File.Exists(jsonPath))
            File.WriteAllText(jsonPath, "[]");
        List<UIPanel> list = JsonMapper.ToObject<List<UIPanel>>(File.ReadAllText(jsonPath));

        return list;
    }

    public void WriteJsonFile(string jsonPath, List<UIPanel> list)
    {
        string json = JsonMapper.ToJson(list);
        File.WriteAllText(jsonPath, json);
    }


    public void UIPanelInfoSaveInJson()
    {
        panelList = ReadJsonFile(jsonPath);//读取现有json里的UIPanelList

        //读取储存面板prefab的文件夹的信息
        DirectoryInfo folder = new DirectoryInfo(panelPrefabPath);
        //遍历储存面板prefab的文件夹里每一个prefab的名字，并把名字转换为对应的UIPanelType
        //再检查UIPanelType是否存在于List里,若存在List里则更新path,若不存在List里则加上
        foreach (FileInfo file in folder.GetFiles("*." +
                                                  "prefab" +
                                                  ""))
        {
            EnumClass.UIPanelType type = (EnumClass.UIPanelType)Enum.Parse(typeof(EnumClass.UIPanelType), file.Name.Replace(".prefab", ""));
            //这里的path是相对路径，因为加载时使用的是Resources.load
            string path = @"Prefabs/UI/" + file.Name.Replace(".prefab", "");
        
            bool UIPanelExistInList = false;//默认该UIPanel不在现有UIPanelList中

            //在List里查找type相同的UIPanel
            //SearchPanelForType是一个List的扩展方法，具体见Extension部分
            UIPanel uIPanel = panelList.SearchPanelForType(type);

            if (uIPanel != null)//UIPanel在该List中,更新path值
            {
                uIPanel.UIPanelPath = path;
                UIPanelExistInList = true;
            }

            if (UIPanelExistInList == false)//UIPanel不在List中,加上该UIPanel
            {
                UIPanel panel = new UIPanel
                {
                    panel_type = type,
                    UIPanelPath = path
                };
                panelList.Add(panel);
            }
        }

        WriteJsonFile(jsonPath, panelList);//把更新后的UIPanelList写入Json

        //AssetDatabase.Refresh();//刷新资源
    }


    public UIBasePanel GetPanel(EnumClass.UIPanelType panel_type)
    {
        if (panelDict == null)
            panelDict = new Dictionary<EnumClass.UIPanelType, UIBasePanel>();
        //【扩展发放】通过type查找字典里对应的UIBasePanel，若找不到则返回null，具体见Extension部分
        UIBasePanel panel = panelDict.TryGetValue(panel_type);

        //在现有字典里没有找到
        //只能去json里找type对应的prefab的路径并加载
        //再加进字典里以便下次在字典中查找
        if (panel == null)
        {
            //【扩展方法】通过Type查找列表里对应的UIPanel，若找不到则返回null，具体见Extension部分
            string path = panelList.SearchPanelForType(panel_type).UIPanelPath;
            if (path == null)
                throw new Exception("找不到该UIPanelType的Prefab");

            if (Resources.Load(path) == null)
                throw new Exception("找不到该Path的Prefab");
            //实例化prefab
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            //把面板设为Canvas的子物体，false表示不保持worldPosition，而是根据Canvas的坐标设定localPosition
            instPanel.transform.SetParent(CanvasTransform, false);

            panelDict.Add(panel_type, instPanel.GetComponent<UIBasePanel>());

            return instPanel.GetComponent<UIBasePanel>();
        }

        return panel;
    }

    // UIPANEL 栈
    private Stack<UIBasePanel> panelStack;


    //把指定类型的panel入栈,并显示在场景中
    public void PushPanel(EnumClass.UIPanelType panel_type)
    {
        if (panelStack == null)
            panelStack = new Stack<UIBasePanel>();

        //判断栈里是否有其他panel,若有,则把原栈顶panel设定其状态为暂停(OnPause)
        if (panelStack.Count > 0)
        {
            UIBasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        UIBasePanel panel = GetPanel(panel_type);

        //把指定类型的panel入栈并设定其状态为进入场景(OnEnter)
        panelStack.Push(panel);
        panel.OnEnter();
    }

    //把栈顶panel出栈,并从场景中消失
    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<UIBasePanel>();

        //检查栈是否为空，若为空则直接退出方法
        if (panelStack.Count <= 0) return;

        //把栈顶panel出栈，并把该panel状态设为退出场景(OnExit)
        UIBasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        //再次检查出栈栈顶Panel后栈是否为空
        //若为空，直接退出方法
        //若不为空，则把新的栈顶Panel状态设为继续(OnResume)
        if (panelStack.Count <= 0) return;

        UIBasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }



}
