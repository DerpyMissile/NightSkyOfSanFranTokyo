using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public GameObject player;
    public BoxCollider2D[] walls;
    public BoxCollider2D[] cameraNoWalls;
    public Camera mainCam;
    public Color blackScreen;
    public DialogueInitiator9000 dia;
    bool cameraDetached = false;
    bool woahCoolManeuver = false;
    float time = 0.0f;
    // Start is called before the first frame update

    private IEnumerator waitASec(){
        cameraDetached = !cameraDetached;
        yield return new WaitForSeconds(1.0f);
        StopCoroutine(waitASec());
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!cameraDetached){
            mainCam.transform.parent = player.transform;
            mainCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2, player.transform.position.z-1);
        }

        if(!woahCoolManeuver){
            for(int i=0; i<cameraNoWalls.Length; ++i){
                if(player.GetComponent<BoxCollider2D>().IsTouching(cameraNoWalls[i]) && time > 1.0f){
                    Debug.Log("istouch");
                    time = 0;
                    mainCam.transform.parent = null;
                    mainCam.transform.position = new Vector3(mainCam.transform.position.x, player.transform.position.y+2, mainCam.transform.position.z-10);
                    cameraDetached = !cameraDetached;
                    //StartCoroutine(waitASec());
                    //i--;
                    //the above code breaks everything lmao
                }
            }
        }

        for(int i=0; i<walls.Length; ++i){
            if(player.GetComponent<BoxCollider2D>().IsTouching(walls[i])){

                //MIGHT NOT BE THE BEST PLACE TO PUT IT BUT DUCK IT WE BALL
                if(Chapter.getChap() <= 0 && i>1){
                    //this is if Chi Chi decides to go right first thing
                    //reminder for Hao to make a text thing where it goes Chi Chi kinda says no
                    player.transform.position = new Vector3(cameraNoWalls[i].transform.position.x-5, player.transform.position.y, player.transform.position.z);
                    woahCoolManeuver = false;
                    cameraDetached = false;
                    return;
                }

                woahCoolManeuver = true;
                if(i%2==0){
                    player.transform.position = new Vector3(walls[i+1].transform.position.x, player.transform.position.y, player.transform.position.z);
                    //do a +5
                    mainCam.transform.parent = walls[i+1].transform;
                    mainCam.transform.position = walls[i+1].transform.position;
                    for(int j=0; j<4; ++j){
                        player.transform.position = new Vector3(walls[i+1].transform.position.x + j, player.transform.position.y, player.transform.position.z);
                    }
                }else{
                    player.transform.position = new Vector3(walls[i-1].transform.position.x, player.transform.position.y, player.transform.position.z);
                    //do a -5
                    mainCam.transform.parent = walls[i-1].transform;
                    mainCam.transform.position = walls[i-1].transform.position;
                    for(int k=0; k<4; ++k){
                        player.transform.position = new Vector3(walls[i-1].transform.position.x - k, player.transform.position.y, player.transform.position.z);
                    }
                }
                mainCam.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z-10);
                woahCoolManeuver = false;
            }
        }

        time += Time.deltaTime;
    }
}
