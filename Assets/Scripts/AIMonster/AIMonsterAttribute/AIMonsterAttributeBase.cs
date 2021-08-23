using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerGuilt;
// [Serializable]
namespace AIMonster
{
    public class AIMonsterAttributeBase : MonoBehaviour
    {
        // 怪物AI的基础属性
        public int AIMonsterMaxHealth { get; set; }

        public int AIMonsterMaxDefend { get; set; }

        public int AIMonsterMaxAttack { get; set; }

        private int AIMonsterCurrentHealth;

        public virtual int GetMonsterCurrentHp()
        {
            return AIMonsterCurrentHealth;
        }

        public virtual void SetMonsterCurrentHp(int target_hp)
        {
            AIMonsterCurrentHealth = target_hp;
        }

        public virtual void AIMonsterTakeDemage(int demage)
        {
            AIMonsterCurrentHealth = AIMonsterCurrentHealth - demage;
        }

        public virtual void AIMonsterInfluenceByStatus(EnumClass.FloatStatus status)
        {
            //todo:
        }



    }
}