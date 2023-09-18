using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    public static int health;
    TextMeshProUGUI HealthScore;
    void Start()
    {
        health=3;
        HealthScore=GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        HealthScore.text=health.ToString();
        
    }
}
