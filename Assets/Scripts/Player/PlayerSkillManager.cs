using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerSkillManager : MonoBehaviour
    {
        private static PlayerSkillManager PlayerSkillManagerInstance;
        
        public static PlayerSkillManager GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (PlayerSkillManagerInstance == null)
            {
                PlayerSkillManagerInstance = new PlayerSkillManager();
            }
            return PlayerSkillManagerInstance;
        }
        
        //用一个Dic来储存数据的值吧
        Dictionary<string,int> skill_map = new Dictionary<string, int>();

        private PlayerSkillManager()
        {
            // 读取XML
            
            
        }

        public void ChangePlayerSkillDic(string key_str,int add_tion_count)
        {
            skill_map[key_str] = skill_map[key_str] + add_tion_count;
        }



    }
}