// +
using UnityEngine;

public class ExpandingAndSqueezingCube : MonoBehaviour
{
    private float timer = 0f;
    private bool isBig;
    public float scale = 5;

    void Update()
    {
        ExpandAndSqueeze();
    }

    private void ExpandAndSqueeze()
    {
        float pingPongValue = Mathf.PingPong(Time.time * 2, scale);
        transform.localScale = new Vector3(pingPongValue, pingPongValue, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.health.SubtractHealth(1);
        }
    }
}
