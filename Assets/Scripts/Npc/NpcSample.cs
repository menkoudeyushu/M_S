using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ServerGuilt;
using UnityEngine.AI;
using UnityEditor;
[System.Serializable]
// NPC的AI控制 基本为人物的固定的行走，播放说话的或什么东西的动画
[RequireComponent(typeof(NavMeshAgent))]
public class NpcSample : NpcBaseAI
{

    public EnumClass.NPC_BEhaviors this_npc_status;
    // Start is called before the first frame update
    private Animator npc_animator;
    [Tooltip("第一个为NPC的当前位置")]
    public List<Transform> npc_move_trans_list= new List<Transform>();
    public float move_speed = 1.5f;
    private NavMeshAgent nav;
    //public Transform parent_transform;
    [SerializeField]
    private int cur_position_index = 0;
    [SerializeField]
    private int next_position_index = 0;
    public Transform this_npc_Pos ;

    private int walk_hash;
    private int run_hash;
    private int doing_work_hash;

     void Start()
    {
        base.Start();
        npc_animator = Npc_base_animator[0];
        nav = GetComponent<NavMeshAgent>();
        TransAnimatorString2Hash();
        if(this_npc_status == EnumClass.NPC_BEhaviors.RUN)
            move_speed = 4.5f;
        nav.speed = move_speed;
    }


    void TransAnimatorString2Hash()
    {
        walk_hash = Animator.StringToHash("IsWalking");
        run_hash = Animator.StringToHash("IsRunning");
        doing_work_hash = Animator.StringToHash("IsDoingWork");
    }



    // Update is called once per frame
    // 这个用AI的寻路
    void Update()
    {
        
        switch (this_npc_status)
        {
            case EnumClass.NPC_BEhaviors.WALK:
                // play walk animation 
                Vector3 lcoal_pos = npc_move_trans_list[cur_position_index].localPosition;
                // 距离的判定需要用当前这个物体的position
                float distence = Vector3.Distance(this_npc_Pos.localPosition,lcoal_pos);;
                if (distence <= 0.1f)
                {
                    if (next_position_index == npc_move_trans_list.Count - 1)
                    {
                        next_position_index = 0;
                    }
                    else
                        next_position_index += 1;

                    cur_position_index = next_position_index;
                }
                nav.destination = npc_move_trans_list[cur_position_index].position;
                // 如果这个NPC没有其他的行为就默认一直开着animator
                npc_animator.SetBool(walk_hash,true);
                npc_animator.SetBool(run_hash, false);
                break;
            case EnumClass.NPC_BEhaviors.RUN:
                Vector3 lcoal_pos_run = npc_move_trans_list[cur_position_index].localPosition;
                // 距离的判定需要用当前这个物体的position
                float distence_run = Vector3.Distance(this_npc_Pos.localPosition, lcoal_pos_run); ;
                if (distence_run <= 0.1f)
                {
                    if (next_position_index == npc_move_trans_list.Count - 1)
                    {
                        next_position_index = 0;
                    }
                    else
                        next_position_index += 1;

                    cur_position_index = next_position_index;
                }
                nav.destination = npc_move_trans_list[cur_position_index].position;
                // 如果这个NPC没有其他的行为就默认一直开着animator
                npc_animator.SetBool(run_hash, true);
                npc_animator.SetBool(walk_hash, false);
                break;





        }
    }

}
