// +
using UnityEngine;
using UnityEngine.Rendering.Universal; 
using System.Collections.Generic;
public class FinalDoorOpener : MonoBehaviour, IObservable
{
    public Vector2 targetPosition;
    public int speed;
    public GameObject Door;
    private bool DoorOpened;
    private Light2D Light;
    private GameObject player;
    private ObjectMover objectMover;
    private List<IObserver> ObserversList = new List<IObserver>();
    
    public void Start()
    {
        Light = GetComponent<Light2D>();

        objectMover = gameObject.AddComponent<ObjectMover>(); 
        objectMover.targetPosition = targetPosition;
        objectMover.speed = speed;
    }

    void Update()
    {
        objectMover.Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player"){
            LightUP();
            Notify();
        }
    }

    private void LightUP(){
        Light.intensity = Mathf.PingPong(Time.time*5, 100);
        Light.pointLightOuterRadius = Mathf.PingPong(0, 100);
    }

    public void Attach(IObserver observer)
    {
        ObserversList.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        ObserversList.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in ObserversList)
        {
            observer.OnNotification(this);
        }
    }
}
