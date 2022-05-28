using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWall : Wall
{

    protected override Vector2 GetViewPort()
    {
        return RightVP.Get();
    }
}
