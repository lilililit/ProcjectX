using UnityEngine;

public class HealthBarclip : MonoBehaviour
{
    public Camera playerCamera;  // Kamera gracza

    void Update()
    {
        if (playerCamera != null)
        {
            // Obróæ Canvas, aby by³ zawsze zwrócony w stronê kamery
            transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward,
                             playerCamera.transform.rotation * Vector3.up);
        }
    }
}
