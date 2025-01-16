using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Maksymalna ilo�� �ycia
    private int currentHealth; // Aktualna ilo�� �ycia

    private void Start()
    {
        // Ustaw pocz�tkowe �ycie na maksymalne
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Zmniejsza �ycie o podan� warto��.
    /// </summary>
    /// <param name="damage">Ilo�� obra�e�</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} ma teraz {currentHealth} punkt�w �ycia.");

        // Sprawd�, czy �ycie jest r�wne zero lub mniej
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Zwi�ksza �ycie o podan� warto��, nie przekraczaj�c maksymalnego.
    /// </summary>
    /// <param name="healing">Ilo�� leczenia</param>
    public void Heal(int healing)
    {
        currentHealth = Mathf.Min(currentHealth + healing, maxHealth);
        Debug.Log($"{gameObject.name} zosta� wyleczony do {currentHealth} punkt�w �ycia.");
    }

    /// <summary>
    /// Usuwa obiekt, gdy �ycie spadnie do zera.
    /// </summary>
    private void Die()
    {
        Debug.Log($"{gameObject.name} zosta� zniszczony.");
        Destroy(gameObject);
    }
}
