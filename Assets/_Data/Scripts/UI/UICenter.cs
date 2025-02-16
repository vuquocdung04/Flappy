using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenter : LoadAutoComponents
{
    [SerializeField] protected BtnPopUpGamePause popUpGamePause;
    [SerializeField] protected BtnPopUpGameOver popUpGameOver;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPopUpGamePause();
        this.LoadPopUpGameOver();
    }

    protected virtual void LoadPopUpGamePause()
    {
        if (this.popUpGamePause != null) return;
        this.popUpGamePause = GetComponentInChildren<BtnPopUpGamePause>();
    }

    protected virtual void LoadPopUpGameOver()
    {
        if (this.popUpGameOver != null) return;
        this.popUpGameOver = GetComponentInChildren<BtnPopUpGameOver>();
    }
}
