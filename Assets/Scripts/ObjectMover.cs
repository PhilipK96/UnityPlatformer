// +
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public int speed;
    public Vector2 targetPosition;
    private Vector2 initialPosition;
    private bool movingForward = true;
   
    void Start()
    {
        initialPosition = transform.position;
    }
    public void Move()
    {
        if (new Vector2(transform.position.x, transform.position.y) != targetPosition & movingForward)
        {
            transform.position = Vector2.MoveTowards(GetCurrentPosition(), targetPosition, Time.deltaTime * speed);
        }

        if (GetCurrentPosition() == targetPosition)
        {
            movingForward = false;

        }

        if (GetCurrentPosition() == initialPosition)
        {
            movingForward = true;

        }

        if (new Vector2(transform.position.x, transform.position.y) != initialPosition & movingForward == false)
        {
            transform.position = Vector2.MoveTowards(GetCurrentPosition(), initialPosition, Time.deltaTime * speed);
        }
    }

    public Vector2 GetCurrentPosition()
    {
        return transform.position;
    }
}
