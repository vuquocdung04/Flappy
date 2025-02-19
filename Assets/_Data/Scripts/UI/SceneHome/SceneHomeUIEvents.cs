using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHomeUIEvents : LoadAutoComponents
{
    [Header("BtnParents")]
    [SerializeField] protected Button btnPlay;
    [SerializeField] protected Button btnSetting;
    [SerializeField] protected Button btnShop;

    [Header("BtnShop")]
    [SerializeField] protected UIShopCtrl uIShopCtrl;
    [Header("BtnSetting")]
    [SerializeField] protected UIAudioSceneHome uIAudioSceneHome;

    [Header("BtnClose")]
    [SerializeField] protected Button btnCloseShop;
    [SerializeField] protected Button btnCloseSetting;
    private void Start()
    {
        btnPlay.onClick.AddListener(OnBtnPlay);
        btnSetting.onClick.AddListener(OnBtnSetting);
        btnShop.onClick.AddListener(OnBtnShop);
        btnCloseShop.onClick.AddListener(OnCloseShop);
        btnCloseSetting.onClick.AddListener(OnCloseSetting);
    }

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnPlay();
        this.LoadBtnSetting();
        this.LoadBtnShop();
        this.LoadUIShopCtrl();
        this.LoadBtnCloseShop();
        this.LoadBtnCloseSetting();
        this.LoadUIAudioSceneHome();
    }

    protected virtual void LoadBtnPlay()
    {
        if (this.btnPlay != null) return;
        this.btnPlay = transform.Find("Parents").Find("BtnPlay").GetComponent<Button>();
    }
    protected virtual void LoadBtnSetting()
    {
        if (this.btnSetting != null) return;
        this.btnSetting = transform.Find("Parents").Find("BtnSetting").GetComponent<Button>();
    }
    protected virtual void LoadBtnShop()
    {
        if (this.btnShop != null) return;
        this.btnShop = transform.Find("Parents").Find("BtnShop").GetComponent<Button>();
    }

    protected virtual void LoadUIShopCtrl()
    {
        if (this.uIShopCtrl != null) return;
        this.uIShopCtrl = GetComponentInChildren<UIShopCtrl>();
        this.uIShopCtrl.gameObject.SetActive(false);
    }

    protected virtual void LoadBtnCloseShop()
    {
        if (this.btnCloseShop != null) return;
        this.btnCloseShop = transform.Find("BtnCloseShop").GetComponent<Button>();
        this.btnCloseShop.gameObject.SetActive(false);
    }
    protected virtual void LoadUIAudioSceneHome()
    {
        if (this.uIAudioSceneHome != null) return;
        this.uIAudioSceneHome = GetComponentInChildren<UIAudioSceneHome>();
        this.uIAudioSceneHome.gameObject.SetActive(false);
    }

    protected virtual void LoadBtnCloseSetting()
    {
        if (this.btnCloseSetting != null) return;
        this.btnCloseSetting = transform.Find("BtnCloseSetting").GetComponent<Button>();
        this.btnCloseSetting.gameObject.SetActive(false);
    }
    #endregion

    public void OnBtnPlay()
    {
        SceneManager.LoadScene(Const.SceneGamePlay);
    }

    public void OnBtnSetting()
    {
        this.uIAudioSceneHome.gameObject.SetActive(true);
        this.btnCloseSetting.gameObject.SetActive(true);
    }

    public void OnBtnShop()
    {
        UIAnimation.ShowPopUp(this.uIShopCtrl.gameObject);
        this.btnCloseShop.gameObject.SetActive(true);
    }
    public void OnCloseShop()
    {
        UIAnimation.HidePopUp(this.uIShopCtrl.gameObject);
        this.btnCloseShop.gameObject.SetActive(false);
    }


    public void OnCloseSetting()
    {
        this.uIAudioSceneHome.gameObject.SetActive(false);
        this.btnCloseSetting.gameObject.SetActive(false);
    }
}
