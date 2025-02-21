using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class TileCtrl : LoadAutoComponents
{
    [SerializeField] protected TileMovement tileMovement;
    public TileMovement TileMovement => tileMovement;

    [SerializeField] protected TileDespawnByDistance tileDespawnByDistance;
    public TileDespawnByDistance TileDespawnByDistance => tileDespawnByDistance;

    [SerializeField] protected TilesCollider tilesCollider;
    public TilesCollider TilesCollider => tilesCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileMovement();
        this.LoadTileDespawnByDistance();
        this.LoadTileCollider();
    }

    protected virtual void LoadTileMovement()
    {
        if (this.tileMovement != null) return;
        this.tileMovement = GetComponentInChildren<TileMovement>();
    }

    protected virtual void LoadTileDespawnByDistance()
    {
        if (this.tileDespawnByDistance != null) return;
        this.tileDespawnByDistance = GetComponentInChildren<TileDespawnByDistance>();
    }

    protected virtual void LoadTileCollider()
    {
        if (this.tilesCollider != null) return;
        this.tilesCollider = GetComponentInChildren<TilesCollider>();
    }

=======
public class TileCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> d492bbc (tile + spawnpoint)
}
