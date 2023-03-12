using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public PlayerManager player;

    public List<SlotUI> slots = new List<SlotUI>();
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleInventory();
        }
        Setup();
    }

    void ToggleInventory(){
        if(!inventoryPanel.activeSelf){
            inventoryPanel.SetActive(true);
        }
        else{
            inventoryPanel.SetActive(false);
        }
    }

    void Setup(){
        if(slots.Count == player.inventory.slots.Count){
            for(int i = 0; i < slots.Count; i++){
                if(player.inventory.slots[i].type != ItemType.NONE){
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else{
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
