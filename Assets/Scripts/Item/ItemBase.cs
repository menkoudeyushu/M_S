using System.Collections;
using System.Collections.Generic;
using ServerGuilt;
using UnityEngine;

namespace  Item
{
    public abstract class ItemBase 
    {
        private EnumClass.ItemType Item_Type
        {
            get;
            set;
        }
        
        private int Item_Count { get; set; }

        public virtual  void UseItem()
        {
            
        }
        
    }
    
}
