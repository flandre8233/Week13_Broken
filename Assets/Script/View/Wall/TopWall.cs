using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWall : Wall
{
    protected override Vector2 GetViewPort()
    {
        return TopVP.Get();
    }
}
