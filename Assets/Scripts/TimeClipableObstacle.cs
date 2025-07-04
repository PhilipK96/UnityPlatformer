// +
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeClipableObstacle : MonoBehaviour
{
    private float timer;
    public float threshold;
    public bool InitialState;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = InitialState;
        GetComponent<BoxCollider2D>().enabled = InitialState;
        GetComponent<ShadowCaster2D>().enabled = InitialState;
    }
    void Update()
    {
        Debug.Log(timer);
        if (timer < threshold)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
            GetComponent<ShadowCaster2D>().enabled = !GetComponent<ShadowCaster2D>().enabled;
        }
    }
}
