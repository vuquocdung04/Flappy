using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : Singleton<ObserverManager>
{
    [SerializeField] protected List<Action> listeners = new List<Action>();

    public virtual void AddListener(Action callback)
    {
        if(!this.listeners.Contains(callback))
            this.listeners.Add(callback);
    }

    public virtual void RemoveListener(Action callback)
    {
        if (!this.listeners.Contains(callback))
            return;
        this.listeners.Remove(callback);
    }

    public virtual void NotifyUpdateScore()
    {
        if (this.listeners.Count == 0) return;
        foreach (var listener in this.listeners)
        {
            listener?.Invoke();
        }
    }
}
