using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ShootingUI : MonoBehaviour
{
    public Slider massSlider;        
    public float minMass = 1f;         
    public float maxMass = 100f;       
    public TMP_Text massDisplayText;   

    void Start()
    {
        massSlider.minValue = minMass;
        massSlider.maxValue = maxMass;
        massSlider.onValueChanged.AddListener(OnMassChanged); // подписываемся на изменение ползунка
        UpdateMassDisplay();                                   // обновляем текст при старте
    }

    void UpdateMassDisplay()
    {
        if (massDisplayText != null)
        {
            massDisplayText.text = "масса снаряда: " + massSlider.value.ToString("F1"); 
        }
    }

    public void OnMassChanged(float newMass)
    {
        UpdateMassDisplay(); // обновляем текст при изменении массы
    }

    public void SetMass(float mass)
    {
        massSlider.value = mass;
        UpdateMassDisplay();
    }
}