using UnityEngine;
using UnityEngine.UI;

public class Citadel : MonoBehaviour
{
    public float maxHealth = 50f;      
    [SerializeField]
    private float currentHealth;       
    [SerializeField]
    private float lerpSpeed = 5f;     

    [SerializeField]
    private Slider healthSlider;      
    [SerializeField]
    private Slider healthSliderDelay;  

    [SerializeField]
    private GameObject breakEffectPrefab; 

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