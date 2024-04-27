using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipe;
    public float height;
    public float timeToSpawn = 3f;
    public float spawnRate = .002f;
    [SerializeField]
    private Bird bird;
    private bool isBirdDead;

    private void IncreaseSpawnRate()
    {
        if(timeToSpawn > .75)
        {
            timeToSpawn -= spawnRate * Time.deltaTime;
        }
    }

    void Update()
    {
        IncreaseSpawnRate();
    }

    private void Awake()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(pipe, new Vector3(4, Random.Range(-height, height), 0), Quaternion.identity);

            yield return new WaitForSeconds(timeToSpawn);

            isBirdDead = bird.isDead;

            if (isBirdDead)
            {
                yield break;
            }
        }

    }
}
