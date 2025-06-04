using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class ShotPrediction : MonoBehaviour
{
    public GameObject[] castleWalls;    
    public GameObject citadel;          
    public Slider massSlider;           
    public TMP_Text predictionText;     

    void Update()
    {
        float mass = massSlider.value;                      
        float totalShots = CalculateTotalShots(mass);     
        predictionText.text = "Минимальное число выстрелов: " + Mathf.Max(Mathf.RoundToInt(totalShots), 3).ToString();
    }

    /// <summary>
    /// Рассчитывает общее количество выстрелов для разрушения замка.
    /// </summary>
    float CalculateTotalShots(float mass)
    {
        float totalShots = 0f;

        // Рассчитываем количество выстрелов для каждой стены
        foreach(var wall in castleWalls)
        {
            if(wall != null)
            {
                var wallScript = wall.GetComponent<CastleWall>();
                totalShots += Mathf.Ceil(wallScript.maxHealth / mass); // количество выстрелов для стены
            }
        }

        // Рассчитываем количество выстрелов для цитадели
        if(citadel != null)
        {
            var citadelScript = citadel.GetComponent<Citadel>();
            totalShots += Mathf.Ceil(citadelScript.maxHealth / mass); // количество выстрелов для цитадели
        }

        // Проверка: если результат меньше 3, устанавливаем ровно 3 выстрела
        return Mathf.Max(totalShots, 3);
    }
}