using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ServerGuilt;
/// <summary>
/// 人物AI的行为有多少种
/// 有初始的一个状态 发现玩家后后转变为巡逻状态，--> 追击 --> 战斗 或者 玩家战斗脱离后 继续巡逻
/// 
/// mesh collider 还是每次都动 加一下吧
/// 
/// </summary>



[RequireComponent(typeof(NavMeshAgent))]

public class MonsterAiHumanCommon :BaseMonstorController
{
    public float HumanMonsterSpeed = 1.2f;

    [Header("初始状态")]
    public EnumClass.NPC_BEhaviors init_status;




}
