using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using ServerGuilt;
public static class StackExtension
{
    //��ջ��panel��ջ,���ӳ�������ʧ
    public static UIPanel SearchPanelForType(this List<UIPanel> list,  EnumClass.UIPanelType panel_type)
    {
        foreach (var item in list)
        {
            if (item.panel_type == panel_type)
                return item;
        }

        return null;
    }
}
