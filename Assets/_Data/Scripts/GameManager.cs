using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : LoadAutoComponents
{
    [SerializeField] protected List<GameObject> prefabs;

    private void Start()
    {
        SpawnSelectedBird();
    }

    protected virtual void SpawnSelectedBird()
    {
        int selectIndex = PlayerPrefs.GetInt(Const.Bird,0);

        if(selectIndex < 0 || selectIndex >= prefabs.Count) selectIndex = 0;

        Instantiate(prefabs[selectIndex], new Vector3(-4,0,0),Quaternion.identity);
    }
}
