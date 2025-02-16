using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileMovement : LoadAutoComponents
{
    [SerializeField] public float tileSpeed = 4f;

    private void Start()
    {
        ObserverManager.Instance.AddObserver(Const.UpSpeedByScore, UpSpeed);
    }
    private void OnDestroy()
    {
        if (ObserverManager.Instance == null) return;
        ObserverManager.Instance.RemoveObserver(Const.UpSpeedByScore, UpSpeed);
    }

    private void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.transform.parent.Translate(Vector3.left * tileSpeed * Time.deltaTime);
    }
    public void UpSpeed()
    {
        tileSpeed += 0.5f;
    }

}
