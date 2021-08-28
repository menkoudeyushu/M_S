using System.Collections;
using System.Collections.Generic;
using ServerGuilt;
using UnityEngine;
using Item;
using Player;
using Tools;

// 这个类为主副武器
// 这个游戏设计的武器 系统有两个武器槽位

namespace Player
{
        public class PlayerWeaponManager : MonoBehaviour
        {
                private static PlayerWeaponManager PlayerWeaponManagerInstance;
                
                public static PlayerWeaponManager GetInstance()
                {
                        // 如果类的实例不存在则创建，否则直接返回
                        if (PlayerWeaponManagerInstance == null)
                        {
                                PlayerWeaponManagerInstance = new PlayerWeaponManager();
                        }

                        return PlayerWeaponManagerInstance;
                }
                private PlayerWeaponManager()
                {
                        // 在构造函数中 读取XML文件的数据
                        // ReadLocalWeaponXml();
                        // ParseList2WeaponList();

                }
                
                // 主角有 主副武器之分，就那那个对线表示当前的武器
                private WeaponBaseSword main_weapon;
                private WeaponBaseSword assistant_weapon;

                /// <summary>
                ///  暂定替换替换武器为把整个武器类对象全部替换掉
                /// </summary>
                /// <returns></returns>
                public void ChangeWeapon(WeaponBaseSword weapon, EnumClass.PlayerMainOrAssistant main_or_ass)
                {
                        if (main_or_ass == EnumClass.PlayerMainOrAssistant.Main)
                        {
                                main_weapon = weapon;
                        }
                        else if(main_or_ass == EnumClass.PlayerMainOrAssistant.Assistant)
                        {
                                assistant_weapon = weapon;
                        }
                        else
                        {
                                
                        }


                }

                public int GetMainWeaponType()
                {
                    // return main_weapon.
                    return 1;
                }
                
                public int GetMainAssistantType()
                { 
                        return 1;   
                }




        }
}
