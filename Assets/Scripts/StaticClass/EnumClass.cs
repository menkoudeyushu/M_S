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

        // 由以后开发待补充
        public enum UIPanelType
        {
            MainMenuPanel,
            SystemSettingPanel,
            PausePanel,
            StorePanel
        };

        // 敌人AI
        public enum HumanMonsterType
        {
            Patrol,// 玩家脱离后 巡逻 或者初始的巡逻
            Chase,//
            Doingwork,
            Talking,
            Dead,
            Attack01,// 只是一些基础的敌人，BOSS敌人的AI 在说吧
            Attack02,
            idle
        };




    }
}
