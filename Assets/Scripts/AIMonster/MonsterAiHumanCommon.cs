using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ServerGuilt;
/// <summary>
/// ����AI����Ϊ�ж�����
/// �г�ʼ��һ��״̬ ������Һ��ת��ΪѲ��״̬��--> ׷�� --> ս�� ���� ���ս������� ����Ѳ��
/// 
/// mesh collider ����ÿ�ζ��� ��һ�°�
/// 
/// </summary>



[RequireComponent(typeof(NavMeshAgent))]

public class MonsterAiHumanCommon :BaseMonstorController
{
    public float HumanMonsterSpeed = 1.2f;

    [Header("��ʼ״̬")]
    public EnumClass.NPC_BEhaviors init_status;




}
