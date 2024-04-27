using UnityEngine;

public class Bird : MonoBehaviour
{
    public float velocity = 1f;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public AudioClip scoreSound;
    public int score = 0;
    public bool isDead;
    [SerializeField]
    private Rigidbody2D rb2D;
    private AudioSource audioSource;

    private void AliveState()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb2D.velocity = Vector2.up * velocity;

            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void DeathState(Collision2D collision)
    {
        if(collision.transform.CompareTag("Death"))
        {
            isDead = true;
        }

        if(hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

    private void ScoreUp(Collider2D collision)
    {
        if (collision.CompareTag("ScoreUp"))
        {
            score += 1;

            if (scoreSound != null)
            {
                audioSource.PlayOneShot(scoreSound);
            }
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AliveState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathState(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreUp(collision);
    }

}
