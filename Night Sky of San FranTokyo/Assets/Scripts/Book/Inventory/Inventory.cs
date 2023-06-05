using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot{
        public ItemType type;
        public int count;

        public Sprite icon;

        public Slot(){
            type = ItemType.NONE;
            count = 0;
        }

        public void AddItem(Item item, int amount){
            this.type = item.type;
            this.count += amount;
            this.icon = item.icon;
        }

        public void RemoveItem(int amount){
            this.count -= amount;
            if(this.count <= 0){
                this.type = ItemType.NONE;
                this.count = 0;
                this.icon = null;
            }
        }

    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots){
        for(int i = 0; i < numSlots; i++){
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Item item, int amount){
        foreach(Slot slot in slots){
            if(slot.type == item.type){
                slot.AddItem(item, amount);
                return;
            }
        }
        
        foreach(Slot slot in slots){
            if(slot.type == ItemType.NONE){
                slot.AddItem(item, amount);
                return;
            }
        }
    }

    public void Remove(ItemType type, int amount){
        foreach(Slot slot in slots){
            if(slot.type == type){
                slot.RemoveItem(amount);
                return;
            }
        }
    }

    public bool HasAtLeast(ItemType type, int amount){
        foreach(Slot slot in slots){
            if(slot.type == type && slot.count >= amount){
                return true;
            }
        }
        return false;
    }

    public int ItemCount(ItemType type){
        foreach(Slot slot in slots){
            if(slot.type == type){
                return slot.count;
            }
        }
        return 0;
    }
}
