using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPauseGame : LoadAutoComponents
{
    [SerializeField] protected Button buttonPause;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButtonPause();
    }

    protected virtual void LoadButtonPause()
    {
        if (this.buttonPause != null) return;
        this.buttonPause = GetComponent<Button>();
    }
}
