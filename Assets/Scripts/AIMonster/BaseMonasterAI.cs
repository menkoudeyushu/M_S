using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[SerializeField]
public  class BaseMonasterAI:MonoBehaviour
{
    private GameObject _game_object;
    public GameObject  Game_object{ get; }

    //ÿһ����monster AI ������һ��Animator
    private Animator[] monster_animator;

    private void Awake()
    {
        monster_animator = GetComponentsInChildren<Animator>();
        if (monster_animator == null)
            Debug.LogError("monster ai do not find animator");
    }
    

}
