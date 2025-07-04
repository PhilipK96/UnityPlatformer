// +
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IObservable
{
    private int health = 1;
    private List<IObserver> observersList = new List<IObserver>();

    public void SubtractHealth(int damage){
        health -= damage;
        Notify();
    }

    public int GetHealth(){
        return health;
    }

    private bool IsAlive()
    {
        return health > 0;
    }

    public void Attach(IObserver observer) 
    {
        observersList.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observersList.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observersList)
        {
            observer.OnNotification(this);
        }
    }
}