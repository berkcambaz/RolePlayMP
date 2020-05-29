using RPG.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayMP.src.Inventory
{
    static public class Item
    {
        public static int itemNumber;
        private static String[] itemName;
        private static int[] itemEffectIndex;
        private static int[] itemEffectModifier;

        public static void InitItems()
        {
            itemNumber = 3;
            itemName = new String[itemNumber];
            itemEffectIndex = new int[itemNumber];
            itemEffectModifier = new int[itemNumber];

            itemName[0] = "Şifa iksiri";
            itemName[1] = "Altın kesesi";
            itemName[2] = "Demir zırh";

            itemEffectIndex[0] = 1;
            itemEffectIndex[1] = 2;
            itemEffectIndex[2] = 3;

            itemEffectModifier[0] = 5;
            itemEffectModifier[1] = 10;
            itemEffectModifier[2] = 5;
        }

        private static void Effect(ref PlayerMP player, int effectIndex, int effectModifier)
        {
            switch (effectIndex)
            {
                case 0:     // No effect
                    break;
                case 1:     // Heal player
                    player.health += effectModifier;
                    break;
                case 2:     // Give gold to player
                    player.gold += effectModifier;
                    break;
                case 3:
                    player.armor += effectModifier;
                    break;
                default:    // No effect
                    break;
            }
        }

        public static void Effect(ref PlayerMP player, int itemIndex)
        {
            Effect(ref player, itemEffectIndex[itemIndex], itemEffectModifier[itemIndex]);
        }

        public static String GetItemName(int index)
        {
            return itemName[index];
        }
    }
}
