using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerGuilt;
public class UIRoot : MonoBehaviour
{
    void Awake()
    {
        //����Ϸ��ʼʱ����MainMenuPanel
        UIManager.Instance.PushPanel(EnumClass.UIPanelType.UiInitPanel);
    }
}

