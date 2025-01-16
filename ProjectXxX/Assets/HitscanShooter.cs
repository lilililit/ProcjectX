using UnityEngine;

public class HitscanShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab pocisku
    public Transform firePoint;         // Pozycja, z kt�rej strzelasz
    public LayerMask hitLayers;         // Warstwy do wykrywania kolizji
    public Camera playerCamera;         // Kamera gracza
    public float projectileSpeed = 50f; // Pr�dko�� pocisku

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Domy�lnie lewy przycisk myszy
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Utw�rz promie� z kamery przez pozycj� myszy
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        // Sprawd�, czy promie� trafia w powierzchni�
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, hitLayers))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(1000f); // Punkt daleko w kierunku promienia
        }

        // Oblicz kierunek z firePoint do celu
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        // Oblicz rotacj� pocisku
        Quaternion projectileRotation = Quaternion.LookRotation(direction);

        // Utw�rz pocisk z poprawn� rotacj�
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, projectileRotation);

        // Ustaw pr�dko�� pocisku
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }

        // Usu� pocisk po 5 sekundach
        Destroy(projectile, 5f);
    }
}
