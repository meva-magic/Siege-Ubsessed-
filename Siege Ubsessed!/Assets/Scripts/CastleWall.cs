using UnityEngine;
using UnityEngine.UI;

public class CastleWall : MonoBehaviour
{
    public float maxHealth = 100f;     // Максимальная прочность стенки
    public float currentHealth;        // Текущая прочность стенки
    public Image healthBar;            // Связанный индикатор здоровья

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();             // Устанавливаем начальную шкалу здоровья
    }

    public void TakeDamage(float percentDamage)
    {
        currentHealth -= maxHealth * percentDamage / 100f;
        UpdateHealthBar();

        if(currentHealth <= 0)
        {
            Destroy(gameObject);       // Удаляем стену, если здоровье исчерпано
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}