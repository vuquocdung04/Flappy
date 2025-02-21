using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : LoadAutoComponents
{
    [SerializeField] protected List<Transform> points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (points.Count >0) return;
        foreach(Transform child in transform)
        {
            points.Add(child);
        }
    }

    public virtual Transform GetRamPos()
    {
        int rand = Random.Range(0, points.Count);
        return points[rand];
    }
}
