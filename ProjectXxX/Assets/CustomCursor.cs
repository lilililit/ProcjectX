using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    // Reference to the red cursor image (assign in Inspector)
    public Image customCursor;

    void Start()
    {
        // Hide the default system cursor
        Cursor.visible = false;
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Update the position of the custom cursor to the center of the screen
        Vector3 cursorPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        customCursor.transform.position = cursorPosition;
    }
}