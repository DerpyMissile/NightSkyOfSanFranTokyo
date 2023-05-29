using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class DialogueInitiator9000 : MonoBehaviour
{
    public DialogueRunner dR;
    public BoxCollider2D Chi;
    public BoxCollider2D[] charactersChiChiCanInteractWith;
    public string[] charaDialogues = {"DocDialogue", "FortDialogue", "BazookaDialogue"};
    public string[] storyDialogues = {"Chapter0Start", "Chapter0HeyGetBackOverHere", "Chapter0Reunion", "Chapter0Mental1", "Chapter0Mental2", "Chapter0Mental3", "Chapter0Mental4", "Chapter0End"};
    public string[] paperLore = {};
    public YarnProject yP1;
    public Image leftPortrait;
    public Image rightPortrait;
    public Image leftChibi;
    public Image rightChibi;
    // Start is called before the first frame update

    IEnumerator fadeInAndOut(Image thing){
        if(thing.color.a == 0){
            for(int i=0; i<255; ++i){
                thing.color += new Color(0, 0, 0, 0.01f);
                yield return new WaitForSeconds(0.05f);
            }
        }else{
            for(int i=0; i<255; ++i){
                thing.color += new Color(0, 0, 0, -0.01f);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    void Awake()
    {
        dR = FindObjectOfType<DialogueRunner>();
        dR.SetProject(yP1);
        StartCoroutine(fadeInAndOut(leftPortrait));
        StartCoroutine(fadeInAndOut(rightPortrait));
        StartCoroutine(fadeInAndOut(leftChibi));
        StartCoroutine(fadeInAndOut(rightChibi));
        //dR.AddCommandHandler<int>("numero", modifyHand);
    }

    public void storyDialogue(int whichPart){
        dR.SetProject(yP1);
        dR.StartDialogue(storyDialogues[whichPart]);
    }

    public void charaDialogue(int whichPart){
        Debug.Log(whichPart);
        dR.SetProject(yP1);
        dR.StartDialogue(charaDialogues[whichPart]);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<charactersChiChiCanInteractWith.Length; ++i){
            if(Chi.IsTouching(charactersChiChiCanInteractWith[i])){
                if(Input.GetKeyDown(KeyCode.E)){
                    charaDialogue(i);
                }
            }
        }
    }
}
