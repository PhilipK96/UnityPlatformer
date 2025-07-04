// +
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SquareCircleObstacle : MonoBehaviour
{
    public int delaySpeed = 1;
    public SquareCircleObstacle Companion;
    public bool isCanFadeBlack;
    public bool isCanFadeWhite;
    public bool isWhite = true;
    public Sprite CircleSprite;
    public Sprite SquareSprite;

    private void Update()
    {
        if (isCanFadeBlack)
        {
            GetComponent<SpriteRenderer>().color -= new Color(0.001f * delaySpeed, 0.001f * delaySpeed, 0.001f * delaySpeed, 0);
            if (GetComponent<SpriteRenderer>().color.r < 0)
            {
                isCanFadeBlack = false;
                isWhite = false;
            }
        }

        if (isCanFadeWhite)
        {
            GetComponent<SpriteRenderer>().color += new Color(0.001f * delaySpeed, 0.001f * delaySpeed, 0.001f * delaySpeed, 0);
            if (GetComponent<SpriteRenderer>().color.r > 1)
            {
                isCanFadeWhite = false;
                isWhite = true;
            }
        }

        if (isCanFadeWhite == false & isCanFadeBlack == false & isWhite)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
        }

        if (isCanFadeWhite == false & isCanFadeBlack == false & !isWhite)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        }


        if (isWhite)
        {
            GetComponent<SpriteRenderer>().sprite = CircleSprite;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<ShadowCaster2D>().castsShadows = false;
        }

        if (!isWhite)
        {
            GetComponent<SpriteRenderer>().sprite = SquareSprite;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<ShadowCaster2D>().castsShadows = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            if (isWhite)
            {
                isCanFadeBlack = true;
                Companion.SetCanFadeWhite();
            }

            if (!isWhite)
            {
                isCanFadeWhite = true;
                Companion.SetCanFadeBlack();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (isWhite)
            {
                isCanFadeBlack = true;
                Companion.SetCanFadeWhite();
            }

            if (!isWhite)
            {
                isCanFadeWhite = true;
                Companion.SetCanFadeBlack();
            }
        }
    }

    public void SetCanFadeWhite()
    {
        isCanFadeWhite = true;
    }

    public void SetCanFadeBlack()
    {
        isCanFadeBlack = true;
    }
}
