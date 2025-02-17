using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnPopUpGameOver : LoadAutoComponents
{
    [SerializeField] protected Transform image;
    [SerializeField] protected Button buttonHome;
    [SerializeField] protected Button buttonReplay;
    [SerializeField] protected Button buttonShare;

    private void Start()
    {
        buttonHome.onClick.AddListener(OnGoHome);
        buttonReplay.onClick.AddListener(OnPlayAgain);
        buttonShare.onClick.AddListener(OnShare);
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
        this.LoadBtnHome();
        this.LoadBtnReplay();
        this.LoadBtnShare();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Image");
    }
    protected virtual void LoadBtnHome()
    {
        if (this.buttonHome != null) return;
        this.buttonHome = transform.Find("Image").Find("BtnHome").GetComponent<Button>();
    }
    protected virtual void LoadBtnReplay()
    {
        if (this.buttonReplay != null) return;
        this.buttonReplay = transform.Find("Image").Find("BtnReplay").GetComponent<Button>();
    }
    protected virtual void LoadBtnShare()
    {
        if (this.buttonShare != null) return;
        this.buttonShare = transform.Find("Image").Find("BtnShare").GetComponent<Button>();
    }
    #endregion

    public void OnGoHome()
    {
        Debug.LogError("GoHome");
    }
    public void OnPlayAgain()
    {
        SceneManager.LoadScene(Const.SceneGamePlay);
        SceneTimeScale.ContinueGame();
    }
    public void OnShare()
    {
        Debug.LogError("Share");

    }
}
