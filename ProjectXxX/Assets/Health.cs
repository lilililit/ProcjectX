using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Maksymalna iloœæ ¿ycia
    private int currentHealth; // Aktualna iloœæ ¿ycia

    private void Start()
    {
        // Ustaw pocz¹tkowe ¿ycie na maksymalne
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Zmniejsza ¿ycie o podan¹ wartoœæ.
    /// </summary>
    /// <param name="damage">Iloœæ obra¿eñ</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} ma teraz {currentHealth} punktów ¿ycia.");

        // SprawdŸ, czy ¿ycie jest równe zero lub mniej
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Zwiêksza ¿ycie o podan¹ wartoœæ, nie przekraczaj¹c maksymalnego.
    /// </summary>
    /// <param name="healing">Iloœæ leczenia</param>
    public void Heal(int healing)
    {
        currentHealth = Mathf.Min(currentHealth + healing, maxHealth);
        Debug.Log($"{gameObject.name} zosta³ wyleczony do {currentHealth} punktów ¿ycia.");
    }

    /// <summary>
    /// Usuwa obiekt, gdy ¿ycie spadnie do zera.
    /// </summary>
    private void Die()
    {
        Debug.Log($"{gameObject.name} zosta³ zniszczony.");
        Destroy(gameObject);
    }
}
