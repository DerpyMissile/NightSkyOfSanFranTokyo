using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType type;
    public Sprite icon;

    public int amount = 0;

    bool colliding = false;

    public PlayerManager player;

    void Update(){
        if(colliding && Input.GetKeyDown(KeyCode.E)){
            player.inventory.Add(this, amount);
            colliding = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        int playerLayer = LayerMask.NameToLayer("player");
        if (other.gameObject.layer == playerLayer)
        {
            colliding = true;
        }
    }
}

public enum ItemType{
    NONE, BAMBOO
}