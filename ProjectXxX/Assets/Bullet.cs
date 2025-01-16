using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10; // Iloœæ obra¿eñ zadawanych przez pocisk

    private void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy obiekt trafiony ma komponent HealthSystem
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            // Zadaj obra¿enia
            health.TakeDamage(damage);
        }

        // Zniszcz pocisk po trafieniu
        Destroy(gameObject);
    }
}
