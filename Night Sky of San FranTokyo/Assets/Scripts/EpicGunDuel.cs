using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

public class EpicGunDuel : MonoBehaviour
{
    public BoxCollider2D Chi;
    public TextMeshProUGUI myText;
    public DialogueRunner dR;
    public YarnProject yP;
    bool canFire = false;
    bool winyesorno = false;

    private IEnumerator leEpicDuel(){
        myText.text = "3...";
        yield return new WaitForSeconds(1);
        myText.text = "[Dramatic Pause]";
        yield return new WaitForSeconds(.5f);
        myText.text = "2...";
        yield return new WaitForSeconds(1);
        myText.text = "[Dramatic Pause]";
        yield return new WaitForSeconds(.5f);
        myText.text = "1...";
        yield return new WaitForSeconds(1);
        myText.text = "[Dramatic Pause]";
        yield return new WaitForSeconds(.5f);
        float waitForHowLong1 = Random.Range(1.0f, 5.0f);
        float waitForHowLong2 = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(waitForHowLong1);
        myText.text = "DRAW!";
        canFire = true;
        // for(float i=0; i<waitForHowLong2; i=i+0.1f){
        //     if(Input.GetKeyDown(KeyCode.E)){
        //         Debug.Log("win?");
        //         goodEndorNot = true;
        //     }
        //     yield return new WaitForSeconds(0.1f);
        // }
        yield return new WaitForSeconds(waitForHowLong2);
        if(winyesorno){
            goodEndGun();
        }else{
            badEndGun();
        }
        yield return 0;
    }

    void goodEndGun(){
        myText.text = "Good end";
        return;
    }

    void badEndGun(){
        myText.text = "Bad end";
        return;
    }

    void startDuel(int num){
        StartCoroutine(leEpicDuel());
    }

    // Start is called before the first frame update
    void Start()
    {
        dR = FindObjectOfType<DialogueRunner>();
        //startDuel();
        dR.SetProject(yP);
        dR.Stop();
        dR.StartDialogue("Gunslinger");
        dR.AddCommandHandler<int>("beginDuel", startDuel);
    }

    // Update is called once per frame
    void Update()
    {
        if(canFire){
            if(Input.GetKeyDown(KeyCode.E)){
                winyesorno = true;
            }
        }
    }
}
