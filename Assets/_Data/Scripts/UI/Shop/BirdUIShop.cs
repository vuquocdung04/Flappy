
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdUIShop : LoadAutoComponents
{
    [SerializeField] protected Button button;
    [SerializeField] protected TMP_Text textButton;
    [SerializeField] protected UIShopCtrl uIShopCtrl;
    [SerializeField] protected int birdIndex;

    private void Start()
    {
        button.onClick.AddListener(OnClickChooseBird);
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
        this.LoadTextButton();
        this.LoadUIShopCtrl();
        this.LoadIndexBird();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponentInChildren<Button>();
    }

    protected virtual void LoadTextButton()
    {
        if (this.textButton != null) return;
        this.textButton = GetComponentInChildren<TMP_Text>();
    }

    protected virtual void LoadUIShopCtrl()
    {
        if (this.uIShopCtrl != null) return;
        this.uIShopCtrl = GetComponentInParent<UIShopCtrl>();
    }

    protected virtual void LoadIndexBird()
    {
        for (int i = 0; i < uIShopCtrl.birdUIShops.Count; i++){
            uIShopCtrl.birdUIShops[i].birdIndex = i;
        }

    }
    #endregion



    public void OnClickChooseBird()
    {
        foreach (var child in this.uIShopCtrl.birdUIShops)
        {
            child.ResetButton();
        }

        button.image.color = Color.green;
        textButton.text = "Selected";

        PlayerPrefs.SetInt(Const.Bird, birdIndex);
        Debug.LogError(PlayerPrefs.GetInt(Const.Bird, birdIndex));
    }

    protected virtual void ResetButton()
    {
        button.image.color = new Color32(255, 143,5,255);
        textButton.text = "Select";
    }
}
