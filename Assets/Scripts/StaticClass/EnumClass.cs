using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace ServerGuilt
{
    public static class EnumClass
    {
        public enum NPC_BEhaviors 
        { 
            WALK, 
            RUN, 
            PLAY, 
            DONGWORK,
            Talking 
        };

        // ���Ժ󿪷�������
        public enum UIPanelType
        {
            MainMenuPanel,
            SystemSettingPanel,
            PausePanel,
            StorePanel
        };

        // ����AI
        public enum HumanMonsterType
        {
            Patrol,// �������� Ѳ�� ���߳�ʼ��Ѳ��
            Chase,//
            Doingwork,
            Talking,
            Dead,
            Attack01,// ֻ��һЩ�����ĵ��ˣ�BOSS���˵�AI ��˵��
            Attack02,
            idle
        };


        public enum ItemType
        {
            Drag,
            FirstEquip,
            SecondEquip,
            Weapon,
        };

        public enum DataUpdateType
        {
            Add,
            Update,
            Delete,
        };
        
        // 剑的攻击类型
        public enum SwordAttackType
        {
            SpikeStrike, // 突刺
            Blunt,// 钝击
        }
        
        // 如果以后还有剑的话，就在增加
        public enum SwordType
        {
            WarSword,// 战剑
            BastardSwords,//混种剑
            Claymore,//苏格兰阔刃大斩剑
            EstocSword,//破甲剑
        }



        //debuff的枚举
        public enum FloatStatus
        {
            ContainBleed,
            Dizziness,
            SlowDown,
            //bu
        }
        
        // 玩家当前装备的类型的枚举值
        public enum PlayerEquipingType
        {
            Head = 0,
            Chest = 1,
            Pants = 2,
            Shoe = 3,
        }

        // 物品的类型
        public enum ItemType()
        {
            Medicine,
            Equipment
            SpecialItem,
        }
        
        // 药品的类型
        public enum DrugType
        {
            HPAddition,
            MPAddition,
        }

        public enum PlayerMainOrAssistant
        {
            Main,
            Assistant,
        }


        
    }
}
