using UnityEngine;
using UnityEngine.UI;

public class Citadel : MonoBehaviour
{
    public float maxHealth = 150f;    // Максимально возможное здоровье цитадели
    public float currentHealth;       // Текущее здоровье цитадели
    public Image healthBar;           // Графическая полоска здоровья

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float percentDamage)
    {
        currentHealth -= maxHealth * percentDamage / 100f;
        UpdateHealthBar();

        if(currentHealth <= 0)
        {
            Destroy(gameObject);       // Уничтожаем цитадель, если жизнь закончилась
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}