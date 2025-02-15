using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : LoadAutoComponents
{
    [SerializeField] protected List<Transform> prefabs;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListPrefabs();
    }

    protected virtual void LoadListPrefabs()
    {
        Transform prefabs = transform.Find("Prefabs");
        foreach (Transform prefab in prefabs)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform RanDomSpawnPrefabs()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
