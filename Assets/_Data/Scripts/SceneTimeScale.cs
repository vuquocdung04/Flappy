using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTimeScale : MonoBehaviour
{
    public static void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public static void ContinueGame()
    {
        Time.timeScale = 1f;
    }
}
