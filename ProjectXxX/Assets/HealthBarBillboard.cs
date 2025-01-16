using UnityEngine;

public class HealthBarclip : MonoBehaviour
{
    public Camera playerCamera;  // Kamera gracza

    void Update()
    {
        if (playerCamera != null)
        {
            // Obr�� Canvas, aby by� zawsze zwr�cony w stron� kamery
            transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward,
                             playerCamera.transform.rotation * Vector3.up);
        }
    }
}
