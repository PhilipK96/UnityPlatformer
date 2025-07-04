// +
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public int speed;
    public Vector2 targetPosition;
    private bool movingForward = true;
    private Rigidbody2D rb;
    private ObjectMover objectMover; 

    void Start()
    {
        objectMover = gameObject.AddComponent<ObjectMover>(); 
        objectMover.targetPosition = targetPosition;
        objectMover.speed = speed;
    }

    private void Update()
    {
        objectMover.Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            GameObject.Find("Player").GetComponent<Player>().health.SubtractHealth(1);
        }
    }
}
