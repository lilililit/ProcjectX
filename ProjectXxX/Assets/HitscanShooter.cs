using UnityEngine;

public class HitscanShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the inspector
    public Transform firePoint;         // The position the projectile spawns from
    public LayerMask hitLayers;         // Layers to detect collision
    public Camera playerCamera;         // Assign the player's camera in the inspector
    public float projectileSpeed = 50f; // Speed of the projectile

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left mouse button by default
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create a ray from the camera through the mouse position
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        // Check if the ray hits a surface
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, hitLayers))
        {
            targetPoint = hit.point; // Get the hit point
        }
        else
        {
            // If no surface is hit, shoot towards a far point along the ray
            targetPoint = ray.GetPoint(1000f);
        }

        // Calculate the direction from the fire point to the target point
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        // Spawn the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Apply velocity to the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
            rb.useGravity = true; // Enable gravity if needed
        }
    }
}
