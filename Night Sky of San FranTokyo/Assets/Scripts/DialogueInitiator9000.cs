using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueInitiator9000 : MonoBehaviour
{
    public DialogueRunner dR;
    public BoxCollider2D Chi;
    public BoxCollider2D[] charactersChiChiCanInteractWith;
    public string[] charaDialogues = {"DocDialogue", "FortDialogue", "BazookaDialogue"};
    public string[] storyDialogues = {"Chapter0Start", "Chapter0HeyGetBackOverHere", "Chapter0Reunion", "Chapter0Mental1", "Chapter0Mental2", "Chapter0Mental3", "Chapter0Mental4", "Chapter0End"};
    public string[] paperLore = {};
    public YarnProject yP1;
    // Start is called before the first frame update
    void Awake()
    {
        dR = FindObjectOfType<DialogueRunner>();
        dR.SetProject(yP1);
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
