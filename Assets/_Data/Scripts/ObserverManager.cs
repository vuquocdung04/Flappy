using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : Singleton<ObserverManager>
{
    /*[SerializeField] protected List<Action> listenerScore = new List<Action>();
    [SerializeField] protected List<Action> listenerPopUp = new List<Action>();*/

    [SerializeField] protected Dictionary<string, List<Action>> listeners = new Dictionary<string, List<Action>>();

    public void AddObserver(string name, Action callback)
    {
        if(!this.listeners.ContainsKey(name))
            this.listeners.Add(name, new List<Action>());

        this.listeners[name].Add(callback);
    }

    public void RemoveObserver(string name, Action callback)
    {
        if (!this.listeners.ContainsKey(name))
            return;
        this.listeners[name].Remove(callback);
    }

    public void Notify(string name)
    {
        if (!this.listeners.ContainsKey(name))
            return;

        foreach(Action action in this.listeners[name])
        {
            action?.Invoke();
        }
    }

    /*#region Score
    public virtual void AddListenerScore(Action callback)
    {
        if(!this.listenerScore.Contains(callback))
            this.listenerScore.Add(callback);
    }

    public virtual void RemoveListenerScore(Action callback)
    {
        if (!this.listenerScore.Contains(callback))
            return;
        this.listenerScore.Remove(callback);
    }

    public virtual void NotifyUpdateScore()
    {
        if (this.listenerScore.Count == 0) return;
        foreach (var listener in this.listenerScore)
        {
            listener?.Invoke();
        }
    }
    #endregion

    //
    public virtual void AddListenerPopUp(Action callback)
    {
        if (!this.listenerPopUp.Contains(callback))
            this.listenerPopUp.Add(callback);
    }

    #region PopUp
    public virtual void RemoveListenerPopUp(Action callback)
    {
        if (!this.listenerPopUp.Contains(callback))
            return;
        this.listenerPopUp.Remove(callback);
    }

    public virtual void NotifyShowPopUpHighScore()
    {
        if (this.listenerPopUp.Count == 0) return;
        foreach (var listener in this.listenerPopUp)
        {
            listener?.Invoke();
        }
    }
    #endregion*/
}
