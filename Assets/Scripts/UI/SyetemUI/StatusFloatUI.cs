
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ServerGuilt;
using UnityEngine.UI;
namespace UI.SyetemUI
{
    //这个类为 物体的跟随UI，记录玩家的当前状态
    // 状态的UI就两个组件
    // --1 状态的图片
    // --2 当前状态的等级
    public class StatusFloatUI :MonoBehaviour
    {
        // float ui prefab
        public GameObject status_ui_prefab;
        // 人物挂载的位置
        public Transform status_ui_trans;
        public Transform ai_up_tran;
        private Transform main_camare;
        // 用一下action
        private Text status_level;
        private Image status_image;
        
        // 状态的UI的持续时间
        private int status_ui_last_time;
        
        //slide
        private Slider slider_trans;
        
        //todo: 需要拿到这个怪物AI的脚本
        void Awake()
        {
            //get s
        }
        
        
        private void OnEnable()
        {
            main_camare = Camera.main.transform;
            foreach (var canvas in FindObjectsOfType<Canvas>())
            {
                if (canvas.renderMode == RenderMode.WorldSpace)
                {
                    // 在个节点挂上 float prefab ui 
                    status_ui_trans = Instantiate(status_ui_prefab,canvas.transform).transform;
                }
            }
            
        }

        void UpdateFloatUI(int current_health,EnumClass.FloatStatus type)
        {
            if (current_health <= 0)
            {
                Destroy(status_ui_prefab);
            }
        }
        
        
        // 更碎AI的 移动
        private void LateUpdate()
        {
            if (status_ui_prefab != null)
            {
                // slider_trans.transform = status_ui_trans;
               //slider_trans.forward = -main_camare.forward;
            }
        }
    }
}