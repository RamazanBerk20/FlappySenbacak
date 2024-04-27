using TMPro;
using UnityEngine;

public class DeathScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + scoreText.text;
    }
}
