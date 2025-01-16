using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnHealthChanged; // Zdarzenie informuj¹ce o zmianie ¿ycia

    [SerializeField] private float maxHealth = 100f; // Maksymalne zdrowie
    public float CurrentHealth { get; private set; } // Aktualne zdrowie
    public float MaxHealth => maxHealth;             // Maksymalne zdrowie (tylko do odczytu)

    private void Start()
    {
        CurrentHealth = maxHealth; // Ustaw pe³ne zdrowie na start

        // Automatyczna inicjalizacja paska zdrowia
        HealthBar healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            healthBar.Initialize(this); // Powi¹¿ pasek zdrowia z tym systemem ¿ycia
        }
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth); // Ogranicz zakres ¿ycia
        OnHealthChanged?.Invoke(); // Wywo³aj zdarzenie zmiany ¿ycia

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject); // Usuñ obiekt, gdy ¿ycie osi¹gnie zero
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth); // Ogranicz zakres ¿ycia
        OnHealthChanged?.Invoke(); // Wywo³aj zdarzenie zmiany ¿ycia
    }
}

