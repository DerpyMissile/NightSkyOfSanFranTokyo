using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueInitiator9000 : MonoBehaviour
{
    public DialogueRunner dR;
    public BoxCollider2D Chi;
    public BoxCollider2D[] charactersChiChiCanInteractWith;
    public string[] charaDialogues = {"MeetDoc", "MeetFort", "BazookaTime"};
    public YarnProject yP;
    // Start is called before the first frame update
    void Awake()
    {
        dR = FindObjectOfType<DialogueRunner>();
        //dR.AddCommandHandler<int>("numero", modifyHand);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<charactersChiChiCanInteractWith.Length; ++i){
            if(Chi.IsTouching(charactersChiChiCanInteractWith[i])){
                if(Input.GetKeyDown(KeyCode.E)){
                    Debug.Log(i);
                    dR.SetProject(yP);
                    dR.StartDialogue(charaDialogues[i]);
                }
            }
        }
    }
}
