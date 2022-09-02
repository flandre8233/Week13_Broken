using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForwardFastCombo : Combo
{
    protected override void Start()
    {
        base.Start();
        Invoke("DoMoveForward", 0);
        Destroy(this, 3f);
    }

    public override void OnBeHit()
    {
        CancelInvoke();
        Destroy(this);
    }

    void DoMoveForward()
    {
        gameObject.AddComponent<BossMoveForward>();
    }



}
