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
    private Animator[] Npc_animator;

    private void Awake()
    {
        Npc_animator = GetComponentsInChildren<Animator>();
        if (Npc_animator == null)
            Debug.LogError("npc ai do not find animator");
    }
    

}
