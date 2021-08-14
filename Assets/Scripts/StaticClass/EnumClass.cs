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





    }
}
