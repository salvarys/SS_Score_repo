using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<Observer> observers = new List<Observer>();

    // Register an observer
    public void RegisterObserver(Observer observer)
    {
        observers.Add(observer);
    }

    // Unregister an observer
    public void UnregisterObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    // Notify all registered observers
    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Notify(this);
        }
    }

    // Example method to end the level and trigger notifications
    public void EndLevel()
    {
        NotifyObservers();
    }
}
