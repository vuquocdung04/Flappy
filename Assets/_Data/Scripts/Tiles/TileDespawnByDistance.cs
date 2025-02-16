using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDespawnByDistance : LoadAutoComponents
{
    [SerializeField] protected float distance;
    [SerializeField] protected float distanceLimit = 40;

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

}
