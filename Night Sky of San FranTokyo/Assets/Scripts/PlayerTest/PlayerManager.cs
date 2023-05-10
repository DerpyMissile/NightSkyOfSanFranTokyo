using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject Player;

    public void Awake(){
        inventory = new Inventory(10);
    }
}
