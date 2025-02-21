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
<<<<<<< HEAD
        this.HidePrefabs();
=======
        //this.HidePrefabs();
>>>>>>> d492bbc (tile + spawnpoint)
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
<<<<<<< HEAD

    public virtual Transform RanDomSpawnPrefabs()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
=======
>>>>>>> d492bbc (tile + spawnpoint)
}
