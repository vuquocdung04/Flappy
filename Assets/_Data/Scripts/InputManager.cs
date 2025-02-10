using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    public virtual bool HandleInputMouseClick()
    {
        return Input.GetMouseButtonDown(0);
    } 
}
