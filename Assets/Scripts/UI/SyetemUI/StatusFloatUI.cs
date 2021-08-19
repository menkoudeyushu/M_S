
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;
using System.Web.Configuration;
using UnityEngine.UI;
namespace UI.SyetemUI
{
    //这个类为 物体的跟随UI，记录玩家的当前状态
    // 状态的UI就两个组件
    // --1 状态的图片
    // --2 当前状态的等级
    public class StatusFloatUI :MonoBehaviour
    {

        public GameObject status_ui_prefab;
        public Transform status_ui_trans;
        private Transform main_camare;
        private Text status_level;
        private Image status_image;

        void Awake()
        {
            main_camare = ;



        }



    }
}