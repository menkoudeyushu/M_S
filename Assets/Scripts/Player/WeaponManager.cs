using System.Collections;
using System.Collections.Generic;
using ServerGuilt;
using UnityEngine;
using Item;
// 这个类保存完玩家所拥有的全部武器物品
public class WeaponManager : MonoBehaviour
{
        private static PlayerBase PlayerInstance;
        private List<string> xml_weapon_list = new List<string>();
        private List<WeaponBaseSword> player_weapon_list = new List<WeaponBaseSword>();

        private WeaponManager()
        {
                // 在构造函数中 读取XML文件的数据
                ReadLocalWeaponXml();
                ParseList2WeaponList();

        }
        
        //用一个list来保存 weapon类

        //todo: 这个静态类在调用的时候读取XML文档
        //XML文件的结构应该为
        //<weapon>
        //    <string1>
        //    <string2>
        //</weapon>
        private void ReadLocalWeaponXml()
        {
                xml_weapon_list = XmlTools.ReadXml();
        }

        private void ParseList2WeaponList()
        {

                for (int i = 0; i < xml_weapon_list.Count; i++)
                {
                        // new class 
                        
                        player_weapon_list.Add();
                }
        }

        private void UpdatePlayerWeaponList(EnumClass.DataUpdateType type,string sword_str,int need_change_count)
        {
                for (int i = 0; i < player_weapon_list.Count; i++)
                {
                        if (player_weapon_list[i].sword_config_str == sword_str)
                        {
                                if (type == EnumClass.DataUpdateType.Add)
                                        player_weapon_list[i].ReduceItemCount(need_change_count);
                                else if (type == EnumClass.DataUpdateType.Update)
                                        player_weapon_list[i].AddItemCount(need_change_count);
                                else if (type == EnumClass.DataUpdateType.Delete)
                                        player_weapon_list.RemoveAt(i);
                                else
                                        ;
                        }
                }
        }
        
        private void UpdatePlayerWeaponList(EnumClass.DataUpdateType type,int count)
        {
                
                        
                
        }
        
        // 由于XML的关系 该游戏中的key 为string 类型 
        private void FindWeaponSingleData(string weapon_id)
        {
                

        }
        
        







}
