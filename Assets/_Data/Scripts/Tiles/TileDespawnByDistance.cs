using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDespawnByDistance : LoadAutoComponents
{
    [SerializeField] protected float distance;
    [SerializeField] public float distanceLimit = 40;

    private void Start()
    {
        ObserverManager.Instance.AddObserver(Const.UpDistanceByScore, UpDistanceLimit);
    }

    private void OnDestroy()
    {
        if (ObserverManager.Instance == null) return;
        ObserverManager.Instance.RemoveObserver(Const.UpDistanceByScore, UpDistanceLimit);
    }

    private void Update()
    {
        this.DesSpawn();
    }

    protected virtual void DesSpawn()
    {
        if (!CanDespawn()) return;
        SimplePool.Despawn(this.transform.parent.gameObject);
    }

    protected virtual bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        return this.distance > this.distanceLimit;
    }

    public void UpDistanceLimit()
    {
        distanceLimit += 5f;
    }
}
