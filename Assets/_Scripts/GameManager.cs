using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Bird bird;
    public Canvas deathCanvas;
    public Canvas scoreCanvas;

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void Awake()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }

    private void Start()
    {
        deathCanvas.enabled = false;
        scoreCanvas.enabled = true;
    }

    private void Update()
    {
        if (bird.isDead)
        {
            deathCanvas.enabled = true;
            scoreCanvas.enabled = false;
        }
    }
}
