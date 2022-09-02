using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCombo : Combo
{

    BossKeepRotate keepRotate;
    protected override void Start()
    {
        base.Start();
        Invoke("AddKeep", 0);
        Invoke("RemoveKeep", 3);
        Invoke("SetBeHitable", 4);
        Invoke("Exit", 8);
    }

    public override void OnBeHit()
    {
        CancelInvoke();
        Exit();
    }

    void SetBeHitable()
    {
        Parent.SetBeHitable();
    }

    void AddKeep()
    {
        keepRotate = gameObject.AddComponent<BossKeepRotate>();
    }
    void RemoveKeep()
    {
        Destroy(keepRotate);
    }

    void Exit()
    {
        gameObject.AddComponent<moveForwardFastCombo>();
    }

}
