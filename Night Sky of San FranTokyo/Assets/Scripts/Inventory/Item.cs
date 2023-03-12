using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType type;
    public Sprite icon;

    public int amount = 0;

    bool colliding = false;

    PlayerManager player;

    void Update(){
        if(colliding && Input.GetKeyDown(KeyCode.E)){
            player.inventory.Add(this, amount);
            colliding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        player = collision.GetComponent<PlayerManager>();

        if(player){
            colliding = true;
        }
    }
}

public enum ItemType{
    NONE, BAMBOO
}