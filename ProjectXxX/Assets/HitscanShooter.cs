using UnityEngine;

public class HitscanShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab pocisku
    public Transform firePoint;         // Pozycja, z której strzelasz
    public LayerMask hitLayers;         // Warstwy do wykrywania kolizji
    public Camera playerCamera;         // Kamera gracza
    public float projectileSpeed = 50f; // Prêdkoœæ pocisku

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Domyœlnie lewy przycisk myszy
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Utwórz promieñ z kamery przez pozycjê myszy
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        // SprawdŸ, czy promieñ trafia w powierzchniê
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

        // Oblicz rotacjê pocisku
        Quaternion projectileRotation = Quaternion.LookRotation(direction);

        // Utwórz pocisk z poprawn¹ rotacj¹
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, projectileRotation);

        // Ustaw prêdkoœæ pocisku
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }

        // Usuñ pocisk po 5 sekundach
        Destroy(projectile, 5f);
    }
}
