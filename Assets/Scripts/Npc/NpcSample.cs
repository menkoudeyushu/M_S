using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ServerGuilt;
using UnityEngine.AI;
[SerializeField]
[System.Serializable]
// NPC��AI���� ����Ϊ����Ĺ̶������ߣ�����˵���Ļ�ʲô�����Ķ���
[RequireComponent(typeof(NavMeshAgent))]
public class NpcSample : NpcBaseAI
{

    EnumClass.NPC_BEhaviors this_npc_status = EnumClass.NPC_BEhaviors.WALK;
    // Start is called before the first frame update
    private Animator npc_animator;
    public List<Transform> npc_move_trans_list= new List<Transform>();
    public float move_speed = 1.5f;
    public NavMeshAgent nav;
     void Start()
    {
        npc_animator = Npc_base_animator[1];
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    // �����AI��Ѱ·
    void Update()
    {
        switch (this_npc_status)
        {
            case EnumClass.NPC_BEhaviors.WALK:
                // play walk animation 
                ;
                break;
            case EnumClass.NPC_BEhaviors.RUN:
                ;
                break;





        }
    }
}
