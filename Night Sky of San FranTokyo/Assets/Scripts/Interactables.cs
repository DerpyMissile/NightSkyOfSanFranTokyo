using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public BoxCollider2D Chi;
    public BoxCollider2D[] sceneInteract;
    public BoxCollider2D[] sceneInteractDestination;
    public BoxCollider2D[] sceneInteractGoBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<sceneInteract.Length; ++i){
            if(Chi.IsTouching(sceneInteract[i])){
                if(Input.GetKeyDown(KeyCode.E)){
                    Chi.transform.position = new Vector3(Chi.transform.position.x, -40, -1);
                }
            }
        }
    }
}
