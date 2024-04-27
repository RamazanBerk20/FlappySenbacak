using System;
using System.Collections;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float velocity = 3f;
    public float destroyTime = 10f;
    private Bird bird;
    private bool isBirdAlive;

    private void Awake()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }

    private void Start()
    {
        StartCoroutine(BeDestroyed());
    }

    private void FixedUpdate()
    {
        isBirdAlive = !bird.isDead;
        transform.position += Vector3.left * velocity * Time.fixedDeltaTime * Convert.ToInt32(isBirdAlive);
    }

    private IEnumerator BeDestroyed()
    {
        if(!isBirdAlive)
        {
            yield break;
        }

        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
    }
}
