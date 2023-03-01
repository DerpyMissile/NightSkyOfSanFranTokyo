using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public GameObject player;
    public BoxCollider2D[] walls;
    public Camera mainCam;
    public Color blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        for(int i=0; i<walls.Length; ++i){
            if(player.GetComponent<BoxCollider2D>().IsTouching(walls[i])){
                if(i==0){
                    player.transform.position = new Vector2(walls[1].transform.position.x, -26);
                }
            }
        }
    }
}
