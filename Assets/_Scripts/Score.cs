using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private Bird bird;
    private int score;
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        score = bird.score;

        textMeshPro.text = score.ToString();
    }
}