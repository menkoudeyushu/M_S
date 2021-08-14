using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[SerializeField]
public  class BaseMonasterAI:MonoBehaviour
{
    
    //每一个的monster AI 都移有一个Animator
    private Animator[] monster_animator;

    public virtual void Awake()
    {
        monster_animator = GetComponentsInChildren<Animator>();
        if (monster_animator == null)
            Debug.LogError("monster ai do not find animator");
    }
    

}
