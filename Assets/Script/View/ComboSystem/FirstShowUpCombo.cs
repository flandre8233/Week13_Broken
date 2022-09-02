using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstShowUpCombo : Combo
{

    protected override void Start()
    {
        base.Start();
        Invoke("DoRotateNomral", 0f);
        Invoke("SetShowHPBar", 2.8f);
        Invoke("Reset", 3f);
    }

    public override void OnBeHit()
    {
    }

    void SetShowHPBar()
    {
        Parent.OnChangedPos();
    }

    protected override void DoRotateNomral()
    {
        BossRotate Rotate = gameObject.AddComponent<BossRotate>();
        Rotate.WantedAngles = 0;
        Rotate.FinishSec = 3f;
    }

    void DoShake()
    {
        Parent.shake.StartShake(2f, 0.3f);
    }

}
