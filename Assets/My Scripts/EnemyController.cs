using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;

    public GameObject player;
    public AudioSource enemyAudio;
    public float soundDistance = 10f;
    public float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (enemyAudio != null)
        {
            enemyAudio.playOnAwake = false;
            enemyAudio.loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector3(direction.x * speed, direction.y * speed, direction.z * speed);

        distance = Vector3.Distance(transform.position, player.transform.position);

        if (enemyAudio != null)
        {
            if (distance <= soundDistance && !enemyAudio.isPlaying)
            {
                enemyAudio.Play();
            }
            else if (distance > soundDistance && enemyAudio.isPlaying)
            {
                enemyAudio.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") ||
            distance <= 0.5f)
        {
            GameManager.Instance.Die();
        }
    }
}
