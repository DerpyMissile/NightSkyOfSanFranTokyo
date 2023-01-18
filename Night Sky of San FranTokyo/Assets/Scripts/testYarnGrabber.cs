using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class testYarnGrabber : MonoBehaviour
{
    DialogueRunner dR;
    // Start is called before the first frame update
    void Awake()
    {
        dR = FindObjectOfType<DialogueRunner>();
        dR.AddCommandHandler<int>("numero", modifyHand);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void modifyHand(int h){
        testHand.changeNumber();
    }
}
