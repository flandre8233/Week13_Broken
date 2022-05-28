using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : Wall
{
    protected override Vector2 GetViewPort()
    {
        return LeftVP.Get();
    }
}
