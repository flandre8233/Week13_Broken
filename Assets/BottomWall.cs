using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : Wall
{
    protected override Vector2 GetViewPort()
    {
        return BottomVP.Get();
    }
}
