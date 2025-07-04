// +
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelEndDoor : MonoBehaviour, IObservable
{
    private List<IObserver> ObserversList = new List<IObserver>();
    private bool CanBeOpened = false;
    private void Start()
    {
        gameObject.GetComponent<Light2D>().intensity = 0;
    }

    private void Update()
    {
        if (CanBeOpened)
        {
            lightTheDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.name == "Player" & CanBeOpened) {
            Notify();
        }
    }

    public void allowDoorOpening(){
        CanBeOpened = true;
    }

    void lightTheDoor()
    {
        gameObject.GetComponent<Light2D>().intensity = Mathf.PingPong(Time.time / 5, 2);
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
