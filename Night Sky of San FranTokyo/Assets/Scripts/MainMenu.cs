using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startGame);
        optionsButton.onClick.AddListener(openOptions);
        quitButton.onClick.AddListener(quitGameLmao);
    }

    void startGame(){

    }

    void openOptions(){
        
    }

    void quitGameLmao(){
        Debug.Log("Night Sky is no more. Another weteor crashes into Santa Monica and everyone dies. The End.");
        Application.Quit();
    }
}
