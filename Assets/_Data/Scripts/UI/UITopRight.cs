
using UnityEngine;

public class UITopRight : LoadAutoComponents
{
    [SerializeField] protected BtnPauseGame btnPauseGame;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnPauseGame();
    }

    protected virtual void LoadBtnPauseGame()
    {
        if (this.btnPauseGame != null) return;
        this.btnPauseGame = GetComponentInChildren<BtnPauseGame>();
    }
}
