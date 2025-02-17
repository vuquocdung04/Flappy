using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGloop : LoadAutoComponents
{
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected float sizeBgLoop = 20f;
    [SerializeField] protected float speed = 4f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }
    private void Update()
    {
        this.LoopBG();
    }
    protected virtual void LoadModel()
    {
        if (_spriteRenderer != null) return;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void LoopBG()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime;
        //60 
        if (Mathf.Abs(Camera.main.transform.position.x - this.transform.position.x) >= 16f)
        {
            this.transform.position = Vector2.zero;
        }
    }

}
