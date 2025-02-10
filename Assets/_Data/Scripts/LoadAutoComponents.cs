using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAutoComponents : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    private void Reset()
    {
        this.LoadComponents();
        this.ResetValues();
    }

    protected virtual void LoadComponents()
    {

    }

    protected virtual void ResetValues()
    {

    }

}
