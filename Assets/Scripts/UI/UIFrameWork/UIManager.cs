using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using System.IO;
using ServerGuilt;
public class UIManager
{

    // ���캯��
    private UIManager()//������ģʽ�����췽��Ϊ˽�У�UIManager��ʵ�����������ڹ���
    {
        //�Զ�����Json�ļ�����ֵ��panelList
        //��ʹ��prefab�ļ����µ���Ϣ��panelList���и���,��д��json�ļ�
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
                //ͨ�����ƻ�ȡCanvas�ϵ�Transform�����Բ�Ҫ��ͬ��Canvas
                canvasTransform = GameObject.Find("Canvas").transform;
            return canvasTransform;
        }
    }


    // ȫ��UI��prefab·��
    readonly string panelPrefabPath = Application.dataPath + @"/Resources/Prefabs/UI";
    readonly string jsonPath = Application.streamingAssetsPath + @"/player_data/Json/UIType.json";

    //����
    private List<UIPanel> panelList;
    //private Dictionary<string, string> panelPathDict;
    private Dictionary<EnumClass.UIPanelType, UIBasePanel> panelDict;

    public List<UIPanel> ReadJsonFile(string jsonPath)
    {
        //����Ҳ���UIJson�ļ������½�һ��Json�ļ���д�롰[]��
        //������½�һ����Json�ļ���Jsonת���᷵��һ��null��Ҳ���Ǻ����list����null��֮��ʹ��list�Ĳ����ͻᱨһ����ָ�����
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
        panelList = ReadJsonFile(jsonPath);//��ȡ����json���UIPanelList

        //��ȡ�������prefab���ļ��е���Ϣ
        DirectoryInfo folder = new DirectoryInfo(panelPrefabPath);
        //�����������prefab���ļ�����ÿһ��prefab�����֣���������ת��Ϊ��Ӧ��UIPanelType
        //�ټ��UIPanelType�Ƿ������List��,������List�������path,��������List�������
        foreach (FileInfo file in folder.GetFiles("*." +
                                                  "prefab" +
                                                  ""))
        {
            EnumClass.UIPanelType type = (EnumClass.UIPanelType)Enum.Parse(typeof(EnumClass.UIPanelType), file.Name.Replace(".prefab", ""));
            //�����path�����·������Ϊ����ʱʹ�õ���Resources.load
            string path = @"Prefabs/UI/" + file.Name.Replace(".prefab", "");
        
            bool UIPanelExistInList = false;//Ĭ�ϸ�UIPanel��������UIPanelList��

            //��List�����type��ͬ��UIPanel
            //SearchPanelForType��һ��List����չ�����������Extension����
            UIPanel uIPanel = panelList.SearchPanelForType(type);

            if (uIPanel != null)//UIPanel�ڸ�List��,����pathֵ
            {
                uIPanel.UIPanelPath = path;
                UIPanelExistInList = true;
            }

            if (UIPanelExistInList == false)//UIPanel����List��,���ϸ�UIPanel
            {
                UIPanel panel = new UIPanel
                {
                    panel_type = type,
                    UIPanelPath = path
                };
                panelList.Add(panel);
            }
        }

        WriteJsonFile(jsonPath, panelList);//�Ѹ��º��UIPanelListд��Json

        //AssetDatabase.Refresh();//ˢ����Դ
    }


    public UIBasePanel GetPanel(EnumClass.UIPanelType panel_type)
    {
        if (panelDict == null)
            panelDict = new Dictionary<EnumClass.UIPanelType, UIBasePanel>();
        //����չ���š�ͨ��type�����ֵ����Ӧ��UIBasePanel�����Ҳ����򷵻�null�������Extension����
        UIBasePanel panel = panelDict.TryGetValue(panel_type);

        //�������ֵ���û���ҵ�
        //ֻ��ȥjson����type��Ӧ��prefab��·��������
        //�ټӽ��ֵ����Ա��´����ֵ��в���
        if (panel == null)
        {
            //����չ������ͨ��Type�����б����Ӧ��UIPanel�����Ҳ����򷵻�null�������Extension����
            string path = panelList.SearchPanelForType(panel_type).UIPanelPath;
            if (path == null)
                throw new Exception("�Ҳ�����UIPanelType��Prefab");

            if (Resources.Load(path) == null)
                throw new Exception("�Ҳ�����Path��Prefab");
            //ʵ����prefab
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            //�������ΪCanvas�������壬false��ʾ������worldPosition�����Ǹ���Canvas�������趨localPosition
            instPanel.transform.SetParent(CanvasTransform, false);

            panelDict.Add(panel_type, instPanel.GetComponent<UIBasePanel>());

            return instPanel.GetComponent<UIBasePanel>();
        }

        return panel;
    }

    // UIPANEL ջ
    private Stack<UIBasePanel> panelStack;


    //��ָ�����͵�panel��ջ,����ʾ�ڳ�����
    public void PushPanel(EnumClass.UIPanelType panel_type)
    {
        if (panelStack == null)
            panelStack = new Stack<UIBasePanel>();

        //�ж�ջ���Ƿ�������panel,����,���ԭջ��panel�趨��״̬Ϊ��ͣ(OnPause)
        if (panelStack.Count > 0)
        {
            UIBasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        UIBasePanel panel = GetPanel(panel_type);

        //��ָ�����͵�panel��ջ���趨��״̬Ϊ���볡��(OnEnter)
        panelStack.Push(panel);
        panel.OnEnter();
    }

    //��ջ��panel��ջ,���ӳ�������ʧ
    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<UIBasePanel>();

        //���ջ�Ƿ�Ϊ�գ���Ϊ����ֱ���˳�����
        if (panelStack.Count <= 0) return;

        //��ջ��panel��ջ�����Ѹ�panel״̬��Ϊ�˳�����(OnExit)
        UIBasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        //�ٴμ���ջջ��Panel��ջ�Ƿ�Ϊ��
        //��Ϊ�գ�ֱ���˳�����
        //����Ϊ�գ�����µ�ջ��Panel״̬��Ϊ����(OnResume)
        if (panelStack.Count <= 0) return;

        UIBasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }



}
