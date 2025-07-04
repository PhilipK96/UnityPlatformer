// +
using UnityEngine;

public class PlatformOnOff : MonoBehaviour
{
    public int transitionTime;
    public bool isOnTopOnStart;
    private bool isTopState;
    
    float time_ = 0.0f;
    void Start()
    {
        SetInitialTop();
    }
    
    void Update()
    {
        Move();
    }

    private void SetInitialTop()
    {
        if (isOnTopOnStart)
        {
            isTopState = true;
            transform.Find("Square").position += new Vector3(0, 2.05f, 0);
        }
    }

    private void ChangePosition()
    {
        Debug.Log("change position");
        if (isTopState)
        {
            transform.Find("Square").position -= new Vector3(0, 2.05f, 0);
            isTopState = false;
        } else
        {
            transform.Find("Square").position += new Vector3(0, 2.05f, 0);
            isTopState = true;
        }
    }

    private void Move()
    {
        time_ += Time.deltaTime;
        if (time_ > 3.0f)
        {
            ChangePosition();
            time_ = 0.0f;
        }
    }
}
