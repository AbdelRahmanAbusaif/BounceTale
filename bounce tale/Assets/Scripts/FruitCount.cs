using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FruitCount : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public static int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.ToString();
    }
}
