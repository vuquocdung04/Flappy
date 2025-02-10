using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileMovement : LoadAutoComponents
{
    [SerializeField] protected float tileSpeed = 4f;
    private void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.transform.parent.Translate(Vector3.left * tileSpeed * Time.deltaTime);
    }

}
