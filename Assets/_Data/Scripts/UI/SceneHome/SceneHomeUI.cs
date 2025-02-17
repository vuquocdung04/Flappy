using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHomeUI : LoadAutoComponents
{
    [Header("BtnParents")]
    [SerializeField] protected Button btnPlay;
    [SerializeField] protected Button btnSetting;
    [SerializeField] protected Button btnShop;

    [Header("BtnShop")]
    [SerializeField] protected UIShopCtrl uIShopCtrl;

    [Header("BtnCloseShop")]
    [SerializeField] protected Button btnCloseShop;
    private void Start()
    {
        btnPlay.onClick.AddListener(OnBtnPlay);
        btnSetting.onClick.AddListener(OnBtnSetting);
        btnShop.onClick.AddListener(OnBtnShop);
        btnCloseShop.onClick.AddListener(OnCloseShop);
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
    #endregion

    public void OnBtnPlay()
    {
        SceneManager.LoadScene(Const.SceneGamePlay);
    }

    public void OnBtnSetting()
    {
        Debug.LogError("Setting");
    }

    public void OnBtnShop()
    {
        this.uIShopCtrl.gameObject.SetActive(true);
        this.btnCloseShop.gameObject.SetActive(true);
    }
    public void OnCloseShop()
    {
        this.uIShopCtrl.gameObject.SetActive(false);
        this.btnCloseShop.gameObject.SetActive(false);
    }
}
