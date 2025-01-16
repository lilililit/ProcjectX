using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFill; // Pasek wype³nienia zdrowia
    private Health health;           // Referencja do systemu ¿ycia

    public void Initialize(Health health)
    {
        this.health = health;

        // Subskrybuj zmiany ¿ycia
        health.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(); // Zaktualizuj pasek na pocz¹tku
    }

    private void UpdateHealthBar()
    {
        if (health != null)
        {
            // Aktualizuj d³ugoœæ paska
            healthBarFill.fillAmount = health.CurrentHealth / health.MaxHealth;

            // Zmieniaj kolor paska w zale¿noœci od ¿ycia
            healthBarFill.color = Color.Lerp(Color.red, Color.green, healthBarFill.fillAmount);
        }
    }

    private void OnDestroy()
    {
        // Usuñ subskrypcjê, aby unikn¹æ b³êdów
        if (health != null)
        {
            health.OnHealthChanged -= UpdateHealthBar;
        }
    }
}
