using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FruitCount : MonoBehaviour
{
    TextMeshProUGUI ScoreText;
    public static int Score;
    // Start is called before the first frame update
    void Start()
    {
        Score= 0 ;
        ScoreText = GetComponent <TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text= Score.ToString();
    }
}
