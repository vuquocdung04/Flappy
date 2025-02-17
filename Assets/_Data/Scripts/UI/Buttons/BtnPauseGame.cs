using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPauseGame : LoadAutoComponents
{
    [SerializeField] protected Button buttonPause;

    private void Start()
    {
        buttonPause.onClick.AddListener(this.OnClickPauseGame);
    }
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

    public virtual void OnClickPauseGame()
    {
        Debug.LogError("Game pause");
        UIManager.Instance.UICenter.BtnPopUpGamePause.gameObject.SetActive(true);
        GameManager.isPauseGame = false;
        SceneTimeScale.PauseGame();
        ObserverManager.Instance.Notify(Const.ListenerCount);
    }
}
