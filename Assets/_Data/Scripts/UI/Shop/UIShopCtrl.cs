using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShopCtrl : LoadAutoComponents
{
    [SerializeField] public List<BirdUIShop> birdUIShops = new List<BirdUIShop>();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIShopCtrl();
    }

    protected virtual void LoadUIShopCtrl()
    {
        if (birdUIShops.Count > 0) return;
        birdUIShops.AddRange(GetComponentsInChildren<BirdUIShop>());
    }
}
