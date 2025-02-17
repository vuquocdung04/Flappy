using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float jumpForce = 5f;
    [SerializeField] protected float rotateSpeed = 1f;
    

    private void Update()
    {
        this.Moving();
    }
    private void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Moving()
    {
        if (!GameManager.isPauseGame) return;
        if (InputManager.Instance.HandleInputMouseClick())
        {
            PlayerCtrl.Rigidbody2D.velocity = Vector2.up * jumpForce;
            ObserverManager.Instance.Notify(Const.AudioClipFly);
        }
    }

    protected virtual void Rotating()
    {
        var bird = PlayerCtrl.Rigidbody2D.velocity.y * rotateSpeed;
        this.transform.parent.rotation = Quaternion.Euler(0,0, bird * rotateSpeed);
    }
}
