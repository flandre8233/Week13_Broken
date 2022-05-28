using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wall : MonoBehaviour
{
    void Start()
    {
        SetPos();
    }

    void SetPos()
    {
        transform.position = Screen.ToWorldPos(GetViewPort());
    }

    protected abstract Vector2 GetViewPort();
}
