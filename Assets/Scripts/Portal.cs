using UnityEngine;

public class Portal : MonoBehaviour
{
    public static bool isActive; 
    protected Vector3 coordinates;
    protected string endpoint_portal_name;
    static GameObject endpoint_portal;

    protected void Update()
    {
        endpoint_portal = GameObject.Find(endpoint_portal_name);
        if (endpoint_portal != null)
        {
            coordinates = endpoint_portal.transform.position;
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (isActive && endpoint_portal != null)
        {
            isActive = false;
            float magnitude = rb.linearVelocity.magnitude;
            rb.linearVelocity = Vector3.zero;
            Vector3 direction = transform.TransformDirection(Vector3.right) - transform.TransformDirection(Vector3.left);
            other.transform.position = coordinates;
            rb.AddForce(direction * magnitude, ForceMode2D.Impulse);
        }
        else isActive = true;
    }
}
