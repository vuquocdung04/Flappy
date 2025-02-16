using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] protected UICenter uICenter;
    [SerializeField] protected UITopRight uITopRight;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUICenter();
        this.LoadUITopRight();
    }

    protected virtual void LoadUICenter()
    {
        if (this.uICenter != null) return;
        this.uICenter = GetComponentInChildren<UICenter>();
    }

    protected virtual void LoadUITopRight()
    {
        if (this.uITopRight != null) return;
        this.uITopRight = GetComponentInChildren<UITopRight>();
    }
}
