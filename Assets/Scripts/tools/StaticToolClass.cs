using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;
using System.Diagnostics;

namespace tools
{
    /// <summary>
    ///  这个方法为静态的类 其中的方法也为静态方法
    /// </summary>
    public static class StaticToolClass
    {
        public static SingleWeapons GetSingleWeaponInDic(string weapon_key)
        {
            if (XmlToolsInstance.weapon_dictionary[weapon_key] == null])
            {
                Debug.Logerror("未在配置中找到物品");
            }
            else
            {
                return XmlToolsInstance.weapon_dictionary[weapon_key];

            }

        }
        
        public static SingleArmour GetSingleArmoueInDic(string armour_key)
        {
            if (XmlToolsInstance.armour_dictionary[armour_key] == null])
            {
                Debug.Logerror("未在配置中找到物品");
            }
            else
            {
                return XmlToolsInstance.armour_dictionary[armour_key];

            }

        }
        
        public static SingleDrug GetSingleDrugInDic(string drug_key)
        {
            if (XmlToolsInstance.drug_dictionary[drug_key] == null])
            {
                Debug.Logerror("未在配置中找到物品");
            }
            else
            {
                return XmlToolsInstance.drug_dictionary[drug_key];

            }

        }

        



    }
}