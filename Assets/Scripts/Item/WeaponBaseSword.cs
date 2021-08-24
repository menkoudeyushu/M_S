using ServerGuilt;
using  Player;
namespace Item
{
    public class WeaponBaseSword : ItemBase
    {
        // XML 配置中的键值
        public string sword_config_str;
        // 剑的类型对应不同的属性
        private EnumClass.SwordAttackType sword_attack_type;

        private int physical_attack_count;
        // 此处的设计为 玩家有多少法力值 * 这个武器对法力值的 接受度
        //private int magic_attack_count;
        private int magic_addition_precent_count;

        private int weapon_count;
        // 耐久度？

        private WeaponBaseSword(string sword_config_Str)
        {
            sword_config_str = sword_config_Str;
            // 从weapon_config 的数据查询得到
            // 不知道 需不需要
        }
        
        
        private WeaponBaseSword(EnumClass.SwordAttackType sword_type,int physical_count,int magic_addition_precent,int count)
        {
            sword_attack_type = sword_type;
            physical_attack_count = physical_count;
            //magic_attack_count = magic_addition_precent * PlayerBase.PlayerMaxMagic;
            magic_addition_precent_count = magic_addition_precent;
            weapon_count = count;
        }
        
        // 如果是武器类型的话，为装备
        public override void UseItem()
        {
            //添加到玩家当前装备的那个 单例上
            
                
            
            
        }
        
        // 
        public void ReduceItemCount(int count)
        {
            weapon_count = weapon_count - count;
        }
        
        public void AddItemCount(int count)
        {
            weapon_count = weapon_count + count;
        }
        
        



    }
}