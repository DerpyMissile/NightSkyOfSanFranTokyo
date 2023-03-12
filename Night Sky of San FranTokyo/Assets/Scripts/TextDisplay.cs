using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    TMP_Text myText;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        myText = GetComponent<TMP_Text>();
    }

    public void UpdateText(string newText)
    {
        myText.text = newText;
    }

    public void ChangeFontSize(float value)
    {
        if(value >= 0)
        {
            myText.fontSize = value;
        }
        else
        {
            Debug.LogError("Provided font size smaller than 0");
        }
    }

    public void TriggerAnim(string triggerName)
    {
        GetComponent<Animator>().SetTrigger(triggerName);
    }
}
