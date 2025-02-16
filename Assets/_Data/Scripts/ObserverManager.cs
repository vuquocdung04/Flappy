using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : Singleton<ObserverManager>
{
    [SerializeField] protected List<Action> listenerScore = new List<Action>();
    [SerializeField] protected List<Action> listenerPopUp = new List<Action>();

    #region Score
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

    public virtual void NotifyShowPopUp()
    {
        if (this.listenerPopUp.Count == 0) return;
        foreach (var listener in this.listenerPopUp)
        {
            listener?.Invoke();
        }
    }
    #endregion
}
