using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public static int HealthCount;
    private TextMeshProUGUI healthScore;
    void Start()
    {
        HealthCount = 3;
        healthScore = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        healthScore.text = HealthCount.ToString();
    }
}
