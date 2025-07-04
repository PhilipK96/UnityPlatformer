// +
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SnakeObstacle : MonoBehaviour
{
    public float transitionTime = 2f;
    public bool isDamagable = false;
    public int orderlyFashion;
    public int NumOfAll;
    private float timer = 0;
    private bool isblack;
    private float offTime;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<ShadowCaster2D>().castsShadows = false;
        transitionTime = transitionTime + orderlyFashion * 0.05f;
        offTime = 2f + transitionTime + (NumOfAll - orderlyFashion) * 0.05f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        TurnOn();
        TurnOff();
    }

    void TurnOn()
    {
        if (!isblack)
        {
            if (timer > transitionTime)
            {
                ChangeState();
                isblack = !isblack;
                return;
            }
        }
    }

    void TurnOff()
    {
        if (isblack) { 
            if (timer > offTime)
            {
                ChangeState();
                isblack = !isblack;
                timer = 0;
            }
        }
    }

    void ChangeState()
    {
        if (isblack) {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<ShadowCaster2D>().castsShadows = false;
        }
        if (!isblack) {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<ShadowCaster2D>().castsShadows = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDamagable)
        {
            if (collision.collider.name == "Player")
            {
                GameObject.Find("Player").GetComponent<Player>().health.SubtractHealth(1);
            }
        }
    }
}