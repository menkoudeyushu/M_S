﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DaiMangou.BridgedData
{
    /// <summary>
    /// Representation Of Link Node Data
    /// </summary>
    [Serializable]
    public class LinkNodeData: NodeData
    {

        public bool Loop;
        public int LoopValue;
        public RouteNodeData loopRoute;
        public int _iterationCount;
        [NonSerialized]
        public int RuntimeIterationCount;
     //   public bool IsOutput;

        public override void OnAfterDeserialize()
        {
           

        }
        public override void OnBeforeSerialize()
        {

        }

        public override void OnEnable()
        {
            _iterationCount = RuntimeIterationCount;
            type = GetType();
            base.OnEnable();
        }

        /// <summary>
        /// executes the base ProcessData function along with this nodes ProcessData function
        /// </summary>
        public override void ProcessData()
        {
            base.ProcessData();

            // here we begin setting up the time loop system which wll hangle character moventment through the past and future
         /*   if (Loop)
            {

                if(_iterationCount == LoopValue)
                {
                    loopRoute.RouteID = loopRoute.AutoSwitchValue;
                }
            }

   */
        }
    }
}