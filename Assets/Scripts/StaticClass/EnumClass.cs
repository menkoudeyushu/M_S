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
        
        
        public enum  ItemType
        {
            Drag,
            FirstEquip,
            SecondEquip,
            Weapon,
        }



    }
}
