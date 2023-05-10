using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{

    public GameObject page1;
    public GameObject page2;

    public GameObject page2Btn;
    // Start is called before the first frame update
    void Start()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page2Btn.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleBook();
        }
    }

    void ToggleBook(){
        if(!page1.activeSelf){
            page1.SetActive(true);
            page2Btn.SetActive(true);
        }
        else{
            page1.SetActive(false);
            page2Btn.SetActive(false);
        }
        page2.SetActive(false);
    }

    public void ToggleSettings(){
        page2.SetActive(true);
        page1.SetActive(false);
    }
}
