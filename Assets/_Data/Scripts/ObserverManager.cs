using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : Singleton<ObserverManager>
{
    [Header("ObserverManager")]
    [SerializeField] protected List<IObserver> observers = new List<IObserver>();

    public virtual void AddListen(IObserver observer)
    {
        observers.Add(observer);
    }

    public virtual void RemoveListen(IObserver observer)
    {
        observers.Remove(observer);
    }

    public virtual void OnScore(int score)
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateScore(score);
        }
    }
}
