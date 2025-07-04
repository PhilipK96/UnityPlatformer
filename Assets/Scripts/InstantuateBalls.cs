// +
using UnityEngine;

public class InstantiateBalls : MonoBehaviour
{
    public float timer; 
    public GameObject[] circlePrefabs; 

    private float timeSinceLastFire = 0f;

    void Start()
    {

        if (circlePrefabs.Length != 5)
        {
            enabled = false; 
        }
    }

    void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        if (timeSinceLastFire > timer)
        {
            FireBalls();
            timeSinceLastFire = 0f;
        }
    }

    void FireBalls()
    {
        Vector3[] positions = new Vector3[]
        {
            transform.position - new Vector3(3, 0, 0),
            transform.position - new Vector3(2, 2, 0),
            transform.position - new Vector3(0, 3, 0),
            transform.position + new Vector3(2, -2, 0),
            transform.position + new Vector3(3, 0, 0)
        };

        for (int i = 0; i < circlePrefabs.Length; i++)
        {
            Instantiate(circlePrefabs[i], positions[i], transform.rotation);
        }
    }
}
