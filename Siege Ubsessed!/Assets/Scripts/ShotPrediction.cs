using UnityEngine;
using UnityEngine.UI; // добавляем пространство имен для UI элементов
using TMPro; // оставляем подключение для TextMesh Pro

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
        predictionText.text = "Минимальное число выстрелов: " + Mathf.Ceil(totalShots).ToString();
    }

    float CalculateTotalShots(float mass)
    {
        float shotsForWalls = 0f;
        foreach (var wall in castleWalls)
        {
            var wallScript = wall.GetComponent<CastleWall>();
            shotsForWalls += wallScript.maxHealth / mass;   
        }

        var citadelScript = citadel.GetComponent<Citadel>();
        float shotsForCitadel = citadelScript.maxHealth / mass;

        return shotsForWalls + shotsForCitadel;
    }
}
