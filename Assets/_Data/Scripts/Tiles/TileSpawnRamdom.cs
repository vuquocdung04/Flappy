using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class TileSpawnRamdom : LoadAutoComponents
{
    [SerializeField] protected TileSpawner tileSpawner;
    public TileSpawner TileSpawner => tileSpawner;

    [SerializeField] protected Transform spawnPoints;

    [Space(10)]
    [Header("Properties")]
    [SerializeField] protected Vector2 pos;
    [SerializeField] protected float ramdomDelay = 2;
    [SerializeField] protected float ramdomTimer = 0;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
        this.LoadTileSpawner();
    }

    protected virtual void LoadTileSpawner()
    {
        if (tileSpawner != null) return;
        tileSpawner = GetComponent<TileSpawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = transform.Find("PointSpawns");
    }

    private void FixedUpdate()
    {
        this.TileSpawning();
    }
    protected virtual void TileSpawning()
    {
        this.ramdomTimer += Time.fixedDeltaTime;
        if (this.ramdomTimer < this.ramdomDelay) return;
        this.ramdomTimer = 0;


        pos = new Vector2(spawnPoints.position.x, Random.Range(-3f,3f));
        Transform prefab = this.tileSpawner.RanDomSpawnPrefabs();
        Transform obj = SimplePool2.Spawn(prefab,pos,Quaternion.identity);
        obj.gameObject.SetActive(true);
    }


}
