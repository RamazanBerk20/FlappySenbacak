using System;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed = 3f;
    private Bird bird;
    private float offset;
    private Renderer backgroundRenderer;
    private bool isBirdAlive;

    private void Awake()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
        backgroundRenderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        isBirdAlive = !bird.isDead;

        offset = Time.time * speed * Convert.ToInt32(isBirdAlive);
        Vector2 newOffset = new Vector2(offset, 0);
        backgroundRenderer.material.mainTextureOffset = newOffset;
    }
}
