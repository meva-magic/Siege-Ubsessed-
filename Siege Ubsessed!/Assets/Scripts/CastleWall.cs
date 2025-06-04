using UnityEngine;
using UnityEngine.UI;

public class CastleWall : MonoBehaviour
{
    public float maxHealth = 15f;      // максимальная прочность стенки
    [SerializeField]
    private float currentHealth;       // текущее здоровье стенки
    [SerializeField]
    private float lerpSpeed = 5f;     // скорость плавного изменения индикатора

    [SerializeField]
    private Slider healthSlider;       // индикатор здоровья
    [SerializeField]
    private Slider healthSliderDelay;  // задержка индикатора

    [SerializeField]
    private GameObject breakEffectPrefab; // префаб спецэффекта

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        healthSliderDelay.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;      
        if (currentHealth <= 0)
        {
            SpawnBreakEffect();        
            Destroy(healthSlider.gameObject); 
            Destroy(gameObject);       
        }
    }

    private void SpawnBreakEffect()
    {
        if(breakEffectPrefab != null)
        {
            Instantiate(breakEffectPrefab, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
        }

        if (healthSlider.value != healthSliderDelay.value)
        {
            healthSliderDelay.value = Mathf.Lerp(
                healthSliderDelay.value,
                healthSlider.value,
                lerpSpeed * Time.deltaTime
            );
        }
    }
}