using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 此脚本为让人物或怪物在两点（多点之间巡逻）
/// </summary>
[System.Serializable]
public class MoveBetween2Points : MonoBehaviour
{
    public int transform_count = 2;
    public List<Transform> patrol_list = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
