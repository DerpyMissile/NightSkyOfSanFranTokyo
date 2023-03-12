using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanPunch : MonoBehaviour
{
    [SerializeField]
    int maxCombo = 50;

    [SerializeField]
    float maxFontSize = 200;
    
    [SerializeField]
    float cameraShakeIntensity = 20f;

    [SerializeField]
    float cameraShakeTime = 0.25f;
    
    [SerializeField] 
    KeyCode punchKey = KeyCode.Space;

    [SerializeField]
    TextDisplay comboDisplay;

    [SerializeField]
    AudioClip[] punchNoises;

    [SerializeField]
    AudioClip cheerNoise;

    // Cached References
    AudioSource m_AudioSource;

    private int combo = 0;
    bool canPunch = true;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canPunch && Input.GetKeyDown(punchKey))
        {
            Punch();
        }
    }

    private void Punch()
    {
        FindObjectOfType<CameraShaker>().ShakeCamera(cameraShakeIntensity, 1f, cameraShakeTime);

        IncreaseCombo();

        comboDisplay.UpdateText("x" + combo.ToString());
        float newFontSize = Mathf.Lerp(36, maxFontSize, (1.0f * combo) / maxCombo);
        comboDisplay.ChangeFontSize(newFontSize);

        comboDisplay.TriggerAnim("Whip Text");

        AudioClip randomPunchNoise = punchNoises[Random.Range(0, punchNoises.Length)];
        m_AudioSource.PlayOneShot(randomPunchNoise);
    }

    public void IncreaseCombo()
    {
        ++combo;

        if (combo >= maxCombo)
        {
            combo = maxCombo;

            PunchingOver();
        }
    }

    private void PunchingOver()
    {
        canPunch = false;

        m_AudioSource.PlayOneShot(cheerNoise);

        // Give popup? and reward
        

        // Transition back to game scene
    }
}
