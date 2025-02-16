using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesCollider : LoadAutoComponents
{
    [SerializeField] protected BoxCollider2D _boxTrigger;
    [SerializeField] protected BoxCollider2D _boxColliderTop;
    [SerializeField] protected BoxCollider2D _boxColliderDown;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider2D();
        this.LoadBoxColliderTop();
        this.LoadBoxColliderDown();
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (_boxTrigger != null) return;
        _boxTrigger = transform.Find("TriggerPoints").GetComponent<BoxCollider2D>();
        _boxTrigger.size = new Vector2(0.5f,2.5f);
        _boxTrigger.offset = new Vector2(0.5f,0);
        _boxTrigger.isTrigger = true;
    }

    protected virtual void LoadBoxColliderTop()
    {
        if (_boxColliderTop != null) return;
        _boxColliderTop = transform.Find("ColliderTop").GetComponent<BoxCollider2D>();
        _boxColliderTop.size = new Vector2(1,10);
        _boxColliderTop.offset = new Vector2(0, 4.5f);
    }
    protected virtual void LoadBoxColliderDown()
    {
        if (_boxColliderDown != null) return;
        _boxColliderDown = transform.Find("ColliderDown").GetComponent<BoxCollider2D>();
        _boxColliderDown.size = new Vector2(1, 10);
        _boxColliderDown.offset = new Vector2(0, -4.5f);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        ObserverManager.Instance.Notify(Const.ScorePlay);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        UIManager.Instance.UICenter.BtnPopUpGameOver.gameObject.SetActive(true);
        SceneTimeScale.PauseGame();
        ObserverManager.Instance.Notify(Const.HightScore);
        ObserverManager.Instance.Notify(Const.ScorePopUp);
    }

}
