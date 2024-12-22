using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    // Sensitivity settings for mouse movement
    public float mouseSensitivityX = 2f;
    public float mouseSensitivityY = 2f;

    // Camera rotation limits for up and down (vertical)
    public float minY = -60f;
    public float maxY = 60f;

    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get the mouse input (movement of the mouse)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;  // Horizontal movement (left/right)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;  // Vertical movement (up/down)

        // Rotate the camera horizontally (yaw) around the Y-axis
        transform.parent.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically (pitch) around the X-axis
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY); // Limit the vertical rotation to prevent over-rotation
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Apply the vertical rotation to the camera
    }


}