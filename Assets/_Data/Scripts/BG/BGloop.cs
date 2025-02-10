using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGloop : LoadAutoComponents
{
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected Transform _playerTrans;
    [SerializeField] protected float sizeBgLoop = 20f;
    [SerializeField] protected float speed = 0.4f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override void ResetValues()
    {
        base.ResetValues();
    }


    private void Start()
    {
        Debug.LogError(this._spriteRenderer.sprite.texture.width/16f);
    }
    private void Update()
    {
        this.LoopBG();
    }

    protected virtual void LoopBG()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime;
        //60 
        if (Mathf.Abs(_playerTrans.transform.position.x - this.transform.position.x) >= 16f)
        {
            this.transform.position = Vector2.zero;
        }
    }

}
