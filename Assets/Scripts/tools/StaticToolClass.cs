using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using tools;
using Tools;

namespace tools
{
    /// <summary>
    ///  这个方法为静态的类 其中的方法也为静态方法
    /// </summary>
    public static class StaticToolClass
    {
        public static XmlTools.SingleWeapons GetSingleWeaponInDic(string weapon_key)
        {
            // if (XmlTools.XmlToolsInstance.weapon_dictionary[weapon_key] == null)
            // {
            //     Debug.LogError("未在配置中找到物品");
            // }
            // else
            // {
                return XmlTools.XmlToolsInstance.weapon_dictionary[weapon_key];

            // }

        }
        
        public static XmlTools.SingleArmour GetSingleArmoueInDic(string armour_key)
        {
            // if (XmlTools.XmlToolsInstance.armour_dictionary[armour_key] == null)
            // {
            //     Debug.LogError("未在配置中找到物品");
            // }
            // else
            // {
                return XmlTools.XmlToolsInstance.armour_dictionary[armour_key];

            //}

        }
        
        public static XmlTools.SingleDrug GetSingleDrugInDic(string drug_key)
        {
            // if (XmlTools.XmlToolsInstance.drug_dictionary[drug_key] == null)
            // {
            //     UnityEngine.Debug.LogError("未在配置中找到物品");
            //     return null;
            // }
            // else
            // {
                return XmlTools.XmlToolsInstance.drug_dictionary[drug_key];

            // }

        }

        



    }
}