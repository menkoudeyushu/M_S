using System.Collections.Generic;
using ServerGuilt;
using UnityEngine;

namespace Player
{
    // 玩家的当前装备系统
    public class PlayerOnEquipManager : MonoBehaviour
    {
        private static PlayerOnEquipManager PlayerEquipManagerInstance;
        
        public static PlayerOnEquipManager GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (PlayerEquipManagerInstance == null)
            {
                PlayerEquipManagerInstance = new PlayerOnEquipManager();
            }
            return PlayerEquipManagerInstance;
        }
        
        // 主角的装备系统 就用string 数组进行储存
        private static int equip_count = 5;

        private string[] player_equiping_array = new string[equip_count];
        // 定义私有构造函数，使外界不能创建该类实例
        // 这个构造函数在初始化的时候，读取玩家装备的XML表，并对数组赋值
        private PlayerOnEquipManager()
        {
            // todo: 读XML并对player_equiping_array赋值
            
            
            
            
        }

        public void ChangePlayerEquipment(EnumClass.PlayerEquipingType type,string target_name)
        {
            // 在这里是否需要判断一下是否有没有
            int ParseEnum2Int = (int) type;
            player_equiping_array[ParseEnum2Int] = target_name;
        }
        
        













    }
}