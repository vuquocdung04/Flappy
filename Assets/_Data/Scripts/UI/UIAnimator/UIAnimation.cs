using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIAnimation
{

    public static void ShowPopUp(GameObject popup, float duration = 0.3f)
    {
        popup.SetActive(true);

        popup.transform.localScale = Vector3.zero;

        Debug.LogError("Before Tween: "+ popup.transform.localScale);

        popup.transform.DOScale(1, duration).SetEase(Ease.OutBack).SetUpdate(true);

        Debug.LogError("Finnal");
        
    }

    public static void HidePopUp(GameObject popup, float duration = 0.3f)
    {
        if (!popup.activeSelf)
        {
            Debug.LogError("Popup is not active");
            return;
        }

        popup.transform.DOScale(0, duration)
            .SetEase(Ease.InBack)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                popup.gameObject.SetActive(false);
            });
    }
    
    public static void HideBtn(GameObject btn, float duration = 0.3f)
    {
        //TODO: ...
    }
    public static void ShowBtn(GameObject btn, float duration = 0.3f)
    {
        //TODO: ...
    }
}
