// +
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VanishingPlatform : MonoBehaviour
{
    public bool state = false;
    public float time = 1f;
    private float counter = 0;

    private void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        if(counter < time)
        {
            counter += Time.deltaTime;
        } else
        {
            counter = 0;
            
            if (state) {
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                GetComponent<BoxCollider2D>().isTrigger = true;
                GetComponent<ShadowCaster2D>().castsShadows = false;
            }
            if (!state) {
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
                GetComponent<BoxCollider2D>().isTrigger = false;
                GetComponent<ShadowCaster2D>().castsShadows = true;
            }
            state = !state;
        }
    }
}