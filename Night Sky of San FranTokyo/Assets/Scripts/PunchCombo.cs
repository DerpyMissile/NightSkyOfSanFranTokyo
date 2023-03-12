using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCombo : MonoBehaviour
{
    private int combo = 0;

    public void IncreaseCombo()
    {
        ++combo;
    }

    public int GetCombo()
    {
        return combo;
    }
}
