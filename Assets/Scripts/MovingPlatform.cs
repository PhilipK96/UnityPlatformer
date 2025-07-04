using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public int speed;
    public float waitTime = 1f;
    public Vector2 targetPosition;
    private Vector2 initialPosition;
    private bool movingForward = true;
    private Rigidbody2D rb;
    private float elapsedTime = 0;
    

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        Move();
    }

    public Vector2 GetCurrentPosition(){
        return transform.position;    
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(this.gameObject.transform); 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    void Move()
    {
        if (new Vector2(transform.position.x, transform.position.y) != targetPosition & movingForward) 
        {
            transform.position = Vector2.MoveTowards(GetCurrentPosition(), targetPosition, Time.deltaTime * speed);
        }

        if (GetCurrentPosition() == targetPosition)
        {
            Wait();
        }

        if (GetCurrentPosition() == initialPosition)
        {
            Wait();
        }

        if (new Vector2(transform.position.x, transform.position.y) != initialPosition & movingForward == false)
        {
            transform.position = Vector2.MoveTowards(GetCurrentPosition(), initialPosition, Time.deltaTime * speed);
        }
    }

    void Wait()
    {
        if(elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
        } else
        {
            elapsedTime = 0;
            movingForward = !movingForward;
        }
    }
}