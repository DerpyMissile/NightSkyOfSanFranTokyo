using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{
    static public SpriteRenderer background;
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.FindWithTag("Background").GetComponent<SpriteRenderer>();
    }

    [YarnCommand("fade_background")]
    static IEnumerator backgroundCoolThing(){
        yield return new WaitForSeconds(1.0f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("ActualGame");

        for(int i=0; i<255; ++i){
            background.color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.05f);
        }

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
