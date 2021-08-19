using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMonster
{
    [System.Serializable]
    public  class BaseMonasterAI:MonoBehaviour
    {
        
        //ÿһ����monster AI ������һ��Animator
        [SerializeField]
        private Animator[] monster_animator;

        public virtual void Awake()
        {
            monster_animator = GetComponentsInChildren<Animator>();
            if (monster_animator == null)
                Debug.LogError("monster ai do not find animator");
        }
        
        

    }
    
}
