using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ServerGuilt;
using System;

// <summary>
// 人物AI的行为有多少种
// 有初始的一个状态 发现玩家后后转变为巡逻状态，--> 追击 --> 战斗 或者 玩家战斗脱离后 继续巡逻
// 
// mesh collider 还是每次都动 加一下吧
// 
// </summary>


[RequireComponent(typeof(NavMeshAgent))]
[System.Serializable]
public class MonsterAiHumanCommon :BaseMonstorController
{
    [Header("初始状态")]
    public EnumClass.HumanMonsterType init_status;

    [SerializeField]
    private EnumClass.HumanMonsterType cur_status;

    private float last_attack_time;
    // 玩家的object
    private GameObject player_attack_target;

    public int AttackForce;

    private Animator animator;
    private NavMeshAgent enemy_nav;
    [Header("检测距离，玩家进入攻击")]
    public int sight_radius = 3;

    [Header("人型敌人AI的移动速度")]
    public float enemy_patrol_speed = 1.3f;
    public float enemt_chase_speed = 2.85f;
    [SerializeField]
    private Vector3 init_transform;

    private Vector3 way_point;
    public float sphere_range = 4;
    [SerializeField]
    private Vector3 random_pos;
    private void Awake()
    {
        this.cur_status = this.init_status;
        animator = this.GetComponent<Animator>();
        enemy_nav = this.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        init_transform = this.transform.position;
        random_pos = GetNewWayPoint();


    }

    private void Update()
    {
        SwitchStatus();
        SwitchAnimation();
    }

    private void SwitchAnimation()
    {
        animator.SetBool("IsRun", this.cur_status == EnumClass.HumanMonsterType.Chase);
        animator.SetBool("IsWalk", this.cur_status == EnumClass.HumanMonsterType.Patrol);
    }

    private void SwitchStatus()
    {
        if (IsFindPlayer())
        {
            //Debug.LogError("has find player");
            this.cur_status = EnumClass.HumanMonsterType.Chase;
        }

        // 返回了原始的位置 就进行 init status 
        if (Vector3.Distance(this.transform.position, init_transform) <= 0.1f && (this.cur_status != EnumClass.HumanMonsterType.Chase))
        {
            this.cur_status = this.init_status;
        }


        switch (cur_status)
        {
            case EnumClass.HumanMonsterType.Chase:
                //TODO: 追击玩家
                //TODO: 返回到巡逻状态
                //TODO: 在攻击范围内攻击
                //TODO: play animation 
                enemy_nav.speed = enemt_chase_speed;
                if (IsFindPlayer())
                {
                    enemy_nav.destination = player_attack_target.transform.position;
                }
                else
                {
                    // 返回巡逻的状态
                    cur_status = EnumClass.HumanMonsterType.Patrol;
                }    



                break;
            case EnumClass.HumanMonsterType.Patrol:
                enemy_nav.speed = enemy_patrol_speed;
                // 如果怪物AI的 距离远离初始的点的话，回到原点，否则，随机巡逻
                float distance_away = Vector3.Distance(this.transform.position, this.init_transform);
                if (distance_away >= sight_radius)
                {
                    enemy_nav.destination = this.init_transform;
                }
                else
                {
                    if (Vector3.Distance(this.random_pos, this.transform.position) <= enemy_nav.stoppingDistance)
                    {
                        this.random_pos = GetNewWayPoint();
                    }
                    else
                    {
                        enemy_nav.destination = random_pos;
                    }
                }
                break;
            case EnumClass.HumanMonsterType.Doingwork:
                break;
            case EnumClass.HumanMonsterType.Talking:
                break;
            case EnumClass.HumanMonsterType.Dead:
                break;
        }
    }

    //TODE:
    void MoveToPlayer(GameObject player_target)
    { 
    }


    private bool IsFindPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sight_radius);

        foreach (var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                player_attack_target = target.gameObject;
                return true;
            }
        }
        player_attack_target = null;
        return false;
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, sight_radius);
    }

    Vector3 GetNewWayPoint()
    {
        float rendomX = UnityEngine.Random.Range(-sphere_range,sphere_range);
        float rendomZ = UnityEngine.Random.Range(-sphere_range, sphere_range);
        Vector3 random_point = new Vector3(this.init_transform.x + rendomX,this.init_transform.y, this.init_transform.z + rendomZ);
        return random_point;
    }


}
