using UnityEngine;
using UnityEngine.UI;

public class Page2Btn : MonoBehaviour
{
    public void OnButtonClick()
    {
        // Get the parent panel's script
        BookManager bookManager = GetComponentInParent<BookManager>();

        // Call the desired function
        bookManager.ToggleSettings();
    }
}
