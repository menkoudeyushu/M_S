using System.Collections;
using System.Collections.Generic;
using ServerGuilt;
using UnityEngine;

namespace Item
{
    // 玩家当前所拥有的全部物品
    public class BagItemManager : MonoBehaviour
    {
        private static BagItemManager BagItemManagerInstance;
        
        private  List<ItemBase> item_list = new  List<ItemBase>();
        // key-->物品的类型  value--> 物品的数量 
        
        private Dictionary<string, int> player_data_dic = new Dictionary<string, int>();
        
        public static BagItemManager GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (BagItemManagerInstance == null)
            {
                BagItemManagerInstance = new BagItemManager();
            }
            return BagItemManagerInstance;
        }
        
        //todo:
        private BagItemManager()
        {
            // 读取玩家数据的XML
            // 依据player_data_dic 的key 值进行在 物品的配置里寻找
        }


    }
}