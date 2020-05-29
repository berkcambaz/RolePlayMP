using RPG.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayMP.src.Inventory
{
    public class Inventory
    {
        private List<int> itemIndices;
        public int totalItems = 11;

        public Inventory()
        {
            itemIndices = new List<int>();
            itemIndices.Add(0);
            itemIndices.Add(1);
            itemIndices.Add(1);
            itemIndices.Add(1);
            itemIndices.Add(1);
            itemIndices.Add(1);
            itemIndices.Add(1);
            itemIndices.Add(2);
            itemIndices.Add(2);
            itemIndices.Add(2);
            itemIndices.Add(2);
        }

        public String GetItemName(int index)
        {
            return Item.GetItemName(itemIndices[index]);
        }

        public void UseItem(ref PlayerMP player, int index)
        {
            Item.Effect(ref player, itemIndices[index]);
            itemIndices.RemoveAt(index);
            totalItems--;
        }

        public void AddItem(int itemIndex)
        {
            itemIndices.Add(itemIndex);
            totalItems++;
        }
    }
}
