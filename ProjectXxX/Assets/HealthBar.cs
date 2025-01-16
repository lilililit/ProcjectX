using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFill; // Pasek wype�nienia zdrowia
    private Health health;           // Referencja do systemu �ycia

    public void Initialize(Health health)
    {
        this.health = health;

        // Subskrybuj zmiany �ycia
        health.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(); // Zaktualizuj pasek na pocz�tku
    }

    private void UpdateHealthBar()
    {
        if (health != null)
        {
            // Aktualizuj d�ugo�� paska
            healthBarFill.fillAmount = health.CurrentHealth / health.MaxHealth;

            // Zmieniaj kolor paska w zale�no�ci od �ycia
            healthBarFill.color = Color.Lerp(Color.red, Color.green, healthBarFill.fillAmount);
        }
    }

    private void OnDestroy()
    {
        // Usu� subskrypcj�, aby unikn�� b��d�w
        if (health != null)
        {
            health.OnHealthChanged -= UpdateHealthBar;
        }
    }
}
