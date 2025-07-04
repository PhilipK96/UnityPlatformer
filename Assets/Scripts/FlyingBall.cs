// +
using UnityEngine;

public class FlyingBall : MonoBehaviour
{
    public Vector2 direction;
    private float lifeTime = 10f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction);
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null && player.health != null)
            {
                player.health.SubtractHealth(1);
            }
        }
    }
}
