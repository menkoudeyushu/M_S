using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[SerializeField]
public class NpcBaseAI : MonoBehaviour
{
    public GameObject _game_object;
    //public GameObject Game_object { get; }

    //每一个的monster AI 都移有一个Animator
    protected Animator[] Npc_base_animator;
    // Start is called before the first frame update
    public virtual void Start()
    {
        Npc_base_animator = GetComponentsInChildren<Animator>();
        if (Npc_base_animator == null)
            Debug.LogError("npc ai do not find animator");
    }

}
