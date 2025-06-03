using UnityEngine;
using UnityEngine.UI;

public class ShootingUI : MonoBehaviour
{
    public Slider massSlider;                      // Ползунок регулирования массы снаряда
    public float minMass = 1f;                     // Минимальная доступная масса снаряда
    public float maxMass = 100f;                   // Максимальная доступная масса снаряда

    void Start()
    {
        massSlider.minValue = minMass;
        massSlider.maxValue = maxMass;
    }

    public void SetMass(float mass)
    {
        massSlider.value = mass;
    }
}