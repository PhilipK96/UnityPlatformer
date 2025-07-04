// +
using UnityEngine;
using UnityEngine.UI;

public class ThrowingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public int throwingForce;
    public bool isThrowUp = true;
    public bool isThrowRight;
    public float throwingThreshold = 0.98f;
    private bool isCanThrow;

    private void Update()
    {
        ChangeColorAndState();  
    }
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Player" & isCanThrow)
        {
            if (isThrowUp)
            {
                rb.AddForceY(throwingForce);
            }
            if (isThrowRight) {
                rb.AddForceX(throwingForce);
            }
        }
    }
    private void ChangeColorAndState()
    {

        GetComponent<Image>().fillAmount = Mathf.PingPong(Time.time, 1); 


        if (GetComponent<Image>().fillAmount > throwingThreshold)
        {
            isCanThrow = true;
        } else
        {
            isCanThrow = false;
        }
    }
}
